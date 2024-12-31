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
        
        public ICommand ShowDetailCommand { get; }
        public ICommand PayCommand { get; }
        public IAsyncRelayCommand LoadPaymentsCommand { get; }
        public ObservableCollection<PaymentModel> _paymentModels { get; set; }
        public PaymentViewModel(IPaymentDao paymentDao, INavigation navigation, IFoodDao foodDao)
        {
            _paymentDao = paymentDao;          
            _navigation = navigation;
            _foodDao = foodDao;
            LoadPaymentsCommand = new AsyncRelayCommand(LoadPayments);
            PayCommand = new RelayCommand<List<CartItemModel>>(AddPayment);
            ShowDetailCommand = new RelayCommand(() => LoadPaymentDetail());
            LoadPaymentsCommand.Execute(null);
            
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

        private float _discount;
        public float Discount
        {
            get => _discount;
            set
            {
                if (SetProperty(ref _discount, value))
                {
                    UpdatePriceAfterDiscount();
                }
            }
        }

        private void UpdatePriceAfterDiscount()
        {
            PriceAfterDiscount = TotalPrice - TotalPrice * (decimal)(Discount / 100);
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
                    Content = "Phần trăm giảm giá không hợp lệ",
                    Title = "Thất bại",
                    CloseButtonText = "OK",
                };
                await failDialog.ShowAsync();
            }
            else
            {
                var PaymentMethod = "";
                if (IsCheckedCash == true)
                {
                    PaymentMethod = "Tiền mặt";
                }
                else if (IsCheckedCard == true)
                {
                    PaymentMethod = "Chuyển khoản";
                }
                var payment = new PaymentModel
                {
                    Id = Guid.NewGuid(),
                    TotalPrice = TotalPrice,
                    Discount = Discount,
                    PriceAfterDiscount = PriceAfterDiscount,
                    AmountReceived = (decimal)AmountReceived,
                    PaymetMethod = PaymentMethod,
                    Change = Change,
                    CreatedDate = DateTime.Now,
                    CreatedBy = LoginViewModel.username
                };
                //Thực hiện cập nhật lại số lượng 
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
            
        }

        private void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            _navigation.NavigateTo(typeof(HomePage));
        }

        private  async void LoadPaymentDetail()
        {
            if (PaymentItem == null) { return; }
            var items = await _paymentDao.GetPaymentDetailById(PaymentItem.Id);
            // Hiển thị dialog
            var dialog = new PaymentDetailDialog
            {
                 XamlRoot = _xamlRoot,
                 SelectedPayment = PaymentItem,
                 SelectedPaymentItems = new ObservableCollection<PaymentDetailModel>(items)
            };
            dialog.PrimaryButtonClick += PaymentDialog_PrimaryButtonClick;
            await dialog.ShowAsync();
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

    }
}
