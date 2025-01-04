using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace POS_Coffee.ViewModels
{
    public class PaymentViewModel : ViewModelBase
    {
        private readonly IPaymentDao _paymentDao;
        private readonly INavigation _navigation;
        private readonly IFoodDao _foodDao;
        private readonly IPromotionDao _promotionDao; // Assuming you have this repository for promotions

        public ICommand ShowDetailCommand { get; }
        public ICommand PayCommand { get; }
        public IAsyncRelayCommand LoadPaymentsCommand { get; }
        public ObservableCollection<PaymentModel> _paymentModels { get; set; }

        public PaymentViewModel(IPaymentDao paymentDao, INavigation navigation, IFoodDao foodDao, IPromotionDao promotionDao)
        {
            _paymentDao = paymentDao;
            _navigation = navigation;
            _foodDao = foodDao;
            _promotionDao = promotionDao; // Initialize the promotion DAO
            
            LoadPaymentsCommand = new AsyncRelayCommand(LoadPayments);
            PayCommand = new RelayCommand<List<CartItemModel>>(AddPayment);
            ShowDetailCommand = new RelayCommand(() => LoadPaymentDetail());
            LoadPaymentsCommand.Execute(null);
            
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
            get => _discount;
            set
            {
                if (SetProperty(ref _discount, value))
                {
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

            // Apply highest discount automatically based on promotions
            await ApplyHighestDiscountForAllProducts(cartItems);

            if ((decimal)AmountReceived < PriceAfterDiscount)
            {
                var failDialog = new ContentDialog()
                {
                    XamlRoot = _xamlRoot,
                    Content = "Số tiền khách thanh toán không hợp lệ",
                    Title = "Thất bại",
                    CloseButtonText = "Ok",
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
                    CloseButtonText = "Ok",
                };
                await failDialog.ShowAsync();
            }
            else
            {
                var payment = new PaymentModel
                {
                    Id = Guid.NewGuid(),
                    TotalPrice = TotalPrice,
                    Discount =(float) Discount,
                    PriceAfterDiscount = PriceAfterDiscount,
                    AmountReceived = (decimal)AmountReceived,
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
                decimal priceAfterDiscount = totalPrice - discountAmount;

                Discount = discountAmount;
                TotalPrice = totalPrice;
                PriceAfterDiscount = priceAfterDiscount;

                Console.WriteLine($"Giảm giá: {discountAmount} | Giá sau giảm: {priceAfterDiscount}");

                return discountAmount;  // Return the discount applied
            }
            else
            {
                Console.WriteLine("Không có chương trình khuyến mãi hợp lệ hoặc giá trị đơn hàng không đủ lớn.");

                return 0;  // No discount applied
            }
        }
    }
}
