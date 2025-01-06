using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.Views;
using Stimulsoft.Report;
using Stimulsoft.Report.Export;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.PointOfService;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace POS_Coffee.ViewModels
{
    public class PaymentViewModel : ViewModelBase
    {
        private readonly IPaymentDao _paymentDao;
        private readonly INavigation _navigation;
        private readonly IFoodDao _foodDao;
        private readonly IPromotionDao _promotionDao;
        private readonly IMembersDao _membersDao;

        public ICommand ShowDetailCommand { get; }
        public ICommand PayCommand { get; }
        public IAsyncRelayCommand LoadPaymentsCommand { get; }
        public ICommand ResetFilterCommand { get; }
        public ObservableCollection<PaymentModel> _paymentModels { get; set; }

        public PaymentViewModel(IPaymentDao paymentDao, INavigation navigation, IFoodDao foodDao, IPromotionDao promotionDao,IMembersDao membersDao)
        {
            _paymentDao = paymentDao;
            _navigation = navigation;
            _foodDao = foodDao;
            _promotionDao = promotionDao;
            _membersDao = membersDao;

            LoadPaymentsCommand = new AsyncRelayCommand(LoadPayments);
            PayCommand = new RelayCommand<List<CartItemModel>>(AddPayment);
            ShowDetailCommand = new RelayCommand(() => LoadPaymentDetail());
            LoadPaymentsCommand.Execute(null);
            ResetFilterCommand = new RelayCommand(ResetFilter);
            _filteredPaymentModels = new ObservableCollection<PaymentModel>();

        }

        private bool _isCheckedCash = true;
        public bool IsCheckedCash
        {
            get => _isCheckedCash;
            set => SetProperty(ref _isCheckedCash, value);
        }

        private bool _isCheckedCard;
        public bool IsCheckedCard
        {
            get => _isCheckedCard;
            set
            {
                if (SetProperty(ref _isCheckedCard, value))
                {
                    AmountReceived = (float)PriceAfterDiscount;
                }
            }
        }
        
        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                if (SetProperty(ref _totalPrice, value))
                {
                    UpdatePriceAfterDiscount();
                }
            }
        }

        public PaymentModel PaymentItem { get; set; }


        private decimal _discount;
        public decimal Discount
        {
            get =>  _discount;
            set
            {
                if (SetProperty(ref _discount, value))
                {
                    OnPropertyChanged(nameof(Discount));
                    UpdatePriceAfterDiscount();
                }
            }
        }

        public async Task SetInitialDiscount(List<CartItemModel> cartItems)
        {
            Discount = await ApplyHighestDiscountForAllProducts(cartItems); // Use await here
        }

        private void UpdatePriceAfterDiscount()
        {
            PriceAfterDiscount = TotalPrice - Discount;
        }

        private float _amountReceived;
        public float AmountReceived
        {
            get => _amountReceived;
            set
            {
                if (SetProperty(ref _amountReceived, value))
                {
                    UpdateChange();
                }
            }
        }

        private decimal _change;
        public decimal Change
        {
            get => _change;
            private set => SetProperty(ref _change, value);
        }

        private bool _isCustomerFound;
        public bool IsCustomerFound
        {
            get => _isCustomerFound;
            set
            {
                if (_isCustomerFound != value)
                {
                    _isCustomerFound = value;
                    OnPropertyChanged(nameof(IsCustomerFound));

                }
            }
        }
        private string _customerPhoneNumber;
        public string CustomerPhoneNumber
        {
            get => _customerPhoneNumber;
            set
            {
                _customerPhoneNumber = value;
                OnPropertyChanged(nameof(CustomerPhoneNumber));
                CheckCustomerExists();
            }
        }



        private string _nameCustomer;
        public string NameCustomer
        {
            get => _nameCustomer;
            set
            {
                SetProperty(ref _nameCustomer, value);
            }
        }
        private int _pointCustomer;
        public int PointCustomer
        {
            get => _pointCustomer;
            set
            {
                if (SetProperty(ref _pointCustomer, value))
                {
                    UpdateDiscount(); 
                }
            }
        }
        private double _cusDiscount;
        public double CusDiscount
        {
            get => _cusDiscount;
            set => SetProperty(ref _cusDiscount, value);
        }


        private decimal _originalPrice;
        public decimal OriginalPrice
        {
            get => _originalPrice;
            set => SetProperty(ref _originalPrice, value);
        }
        private decimal orgdiscount;
        private bool hadChange = false;
        private async void CheckCustomerExists()
        {
            try
            {
                var customer = await _membersDao.getMember(CustomerPhoneNumber);
                if (customer != null)
                {
                    IsCustomerFound = true;
                    NameCustomer = customer.Name;
                    PointCustomer = customer.point;

                    if (!hadChange)
                    {
                        OriginalPrice = PriceAfterDiscount;
                        orgdiscount = Discount;
                        hadChange = true;
                    }

                    decimal customerDiscountAmount = PriceAfterDiscount * (decimal)CusDiscount;
                    PriceAfterDiscount = OriginalPrice - customerDiscountAmount;
                    Discount = orgdiscount + customerDiscountAmount;
                }
                else
                {
                    IsCustomerFound = false;
                    if (hadChange)
                    {
                        PriceAfterDiscount = OriginalPrice;
                        Discount = orgdiscount;
                        hadChange = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any potential errors
                System.Diagnostics.Debug.WriteLine($"Error checking customer: {ex.Message}");
            }
        }

        private void UpdateDiscount()
        {
            if (PointCustomer < 10)
            {
                CusDiscount = 0;
            }
            else if (PointCustomer >= 10 && PointCustomer < 30)
            {
                CusDiscount = 0.03;
            }
            else if (PointCustomer >= 30 && PointCustomer < 50)
            {
                CusDiscount = 0.05;
            }
            else if (PointCustomer >= 50)
            {
                CusDiscount = 0.1;
            }
           
        }



        private decimal _priceAfterDiscount;
        public decimal PriceAfterDiscount
        {
            get => _priceAfterDiscount;
            set
            {
                if (SetProperty(ref _priceAfterDiscount, value))
                {
                    UpdateChange();
                }
            }
        }

        private void UpdateChange()
        {
            Change = (decimal)AmountReceived - PriceAfterDiscount;
        }

        private XamlRoot _xamlRoot;

        public void SetXamlRoot(XamlRoot xamlRoot)
        {
            _xamlRoot = xamlRoot;
        }

        private async Task LoadPayments()
        {
            var payments = await _paymentDao.GetAllPayment();
            _paymentModels = new ObservableCollection<PaymentModel>(payments);
            FilteredPaymentModels = new ObservableCollection<PaymentModel>(_paymentModels);
            PaymentItem = new PaymentModel();
            if (_paymentModels.Any())
            {
                PaymentItem = _paymentModels[0];
            }
            else
            {
                PaymentItem = null;
            }
        }

       

        public async void AddPayment(List<CartItemModel> cartItems)
        {
            if (cartItems == null)
            {
                return;
            }

            //// Apply highest discount automatically based on promotions
            //await ApplyHighestDiscountForAllProducts(cartItems);
                

            if ((decimal)AmountReceived < PriceAfterDiscount)
            {
                var failDialog = new ContentDialog()
                {
                    XamlRoot = _xamlRoot,
                    Content = "Số tiền khách thanh toán không hợp lệ",
                    Title = "Thất bại",
                    CloseButtonText = "OK",
                };
                await failDialog.ShowAsync();
            }
            else if (Discount < 0)
            {
                var failDialog = new ContentDialog()
                {
                    XamlRoot = _xamlRoot,
                    Content = "Giảm giá không hợp lệ",
                    Title = "Thất bại",
                    CloseButtonText = "OK",
                };
                await failDialog.ShowAsync();
            }
            else
            {
                var PaymentMethod = IsCheckedCash ? "Tiền mặt" : "Chuyển khoản";

                if(PriceAfterDiscount>0)
                {
                    int pointupdate = 0;
                    if(PriceAfterDiscount<100000)
                    {
                        pointupdate = 1;
                    }
                    else if (PriceAfterDiscount >= 100000 && PriceAfterDiscount < 300000)
                    {
                        pointupdate = 3;
                    }
                    else if (PriceAfterDiscount >= 300000 && PriceAfterDiscount < 500000)
                    {
                        pointupdate = 5;
                    }       
                    else if (PriceAfterDiscount >= 500000)
                    {
                        pointupdate = 10;
                    }
                    await _membersDao.UpdateMemberPoints(CustomerPhoneNumber, pointupdate);
                }

                var isTrue = true;
                foreach (var item in cartItems)
                {
                    var qnt = await _foodDao.GetQuantityById(item.Id);
                    if (item.Quantity > qnt)
                    {
                        isTrue = false;
                        break;
                    }
                }
                if (isTrue == true)
                {
                    var payment = new PaymentModel
                    {
                        Id = Guid.NewGuid(),
                        TotalPrice = TotalPrice,
                        Discount = (float)Discount,
                        PriceAfterDiscount = PriceAfterDiscount,
                        AmountReceived = (decimal)AmountReceived,
                        PaymetMethod = PaymentMethod,
                        Change = Change,
                        CreatedDate = DateTime.Now,
                        CreatedBy = LoginViewModel.username
                    };

                    // Update quantities
                    await _foodDao.UpdateQuantity(cartItems);
                    await _paymentDao.AddPayment(payment);
                    await _paymentDao.AddPaymentDetail(cartItems, payment.Id);

                    var dialog = new ContentDialog()
                    {
                        XamlRoot = _xamlRoot,
                        Content = "Thanh toán thành công",
                        Title = "Thành công",
                        PrimaryButtonText = "Ok",
                    };
                    dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;
                    await dialog.ShowAsync();
                }
                else
                {
                    var failDialog = new ContentDialog()
                    {
                        XamlRoot = _xamlRoot,
                        Content = "Số lượng món ăn không đủ",
                        Title = "Thất bại",
                        CloseButtonText = "OK",
                    };
                    await failDialog.ShowAsync();
                }

                
            }
        }

        private void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            _navigation.NavigateTo(typeof(HomePage));
        }

        private async void LoadPaymentDetail()
        {
            if (PaymentItem == null) { return; }
            var items = await _paymentDao.GetPaymentDetailById(PaymentItem.Id);
            var dialog = new PaymentDetailDialog
            {
                XamlRoot = _xamlRoot,
                SelectedPayment = PaymentItem,
                SelectedPaymentItems = new ObservableCollection<PaymentDetailModel>(items)
            };
            dialog.PrimaryButtonClick += PaymentDialog_PrimaryButtonClick;
            await dialog.ShowAsync();
        }

        public async Task<decimal> ApplyHighestDiscountForAllProducts(List<CartItemModel> cartItems)
        {
            decimal totalPrice = cartItems.Sum(item => item.Price * item.Quantity);
            var promotions = await _promotionDao.GetActivePromotions();
            var applicablePromotions = promotions.Where(p => p.applicable_to == "Tất cả sản phẩm");

            var bestPromotion = applicablePromotions
                .Where(p => totalPrice >= p.min_order_value)
                .Select(p => new
                {
                    Promotion = p,
                    DiscountAmount = p.discount_type == "Phần trăm"
                        ? totalPrice * (p.discount_value / 100)
                        : p.discount_value
                })
                .OrderByDescending(x => x.DiscountAmount)
                .FirstOrDefault();

            if (bestPromotion != null)
            {
                decimal discountAmount = bestPromotion.DiscountAmount;
                decimal priceAfterDiscount = (totalPrice - discountAmount);

                Discount = discountAmount;
                TotalPrice = totalPrice;
                PriceAfterDiscount = priceAfterDiscount;


                return discountAmount;  
            }
            else
            {

                return 0;  
            }
        }
        
        private void PaymentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var report = new StiReport();
            report.Load("D:/Window Programing/Project/POS_Coffee/POS_Coffee/Reports/Invoice.mrt");
            report.Dictionary.Variables["PaymentID"].Value = PaymentItem.Id.ToString();
            report.Compile();
            report.Render();
            //report.Show();
            var pdfFilePath = Path.Combine("D:/Window Programing/Project/POS_Coffee/POS_Coffee", "PDFs", "Invoice_" + PaymentItem.Id + ".pdf");
            //var pdfExport = new StiPdfExportService();
            report.ExportDocument(StiExportFormat.Pdf, pdfFilePath);
        }

        private ObservableCollection<PaymentModel> _filteredPaymentModels;
        public ObservableCollection<PaymentModel> FilteredPaymentModels
        {
            get => _filteredPaymentModels;
            set => SetProperty(ref _filteredPaymentModels, value);
        }

        private DateTimeOffset? _startDate;
        public DateTimeOffset? StartDate
        {
            get => _startDate;
            set
            {
                if (SetProperty(ref _startDate, value))
                {
                    FilterPayments();
                }
            }
        }

        private DateTimeOffset? _endDate;
        public DateTimeOffset? EndDate
        {
            get => _endDate;
            set
            {
                if (SetProperty(ref _endDate, value))
                {
                    FilterPayments();
                }
            }
        }
        public void FilterPayments()
        {
            if (_paymentModels == null) return;

            var filtered = _paymentModels.AsEnumerable();

            if (StartDate.HasValue)
            {
                filtered = filtered.Where(p => p.CreatedDate.Date >= StartDate.Value.Date);
            }

            if (EndDate.HasValue)
            {
                filtered = filtered.Where(p => p.CreatedDate.Date <= EndDate.Value.Date);
            }

            FilteredPaymentModels = new ObservableCollection<PaymentModel>(filtered);

            if (FilteredPaymentModels.Any())
            {
                PaymentItem = FilteredPaymentModels[0];
            }
            else
            {
                PaymentItem = null;
            }
        }

        private void ResetFilter()
        {
            StartDate = null;
            EndDate = null;
            FilteredPaymentModels = new ObservableCollection<PaymentModel>(_paymentModels);
            if (_paymentModels.Any())
            {
                PaymentItem = _paymentModels[0];
            }
        }

    }
}
