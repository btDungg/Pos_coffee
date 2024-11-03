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

namespace POS_Coffee.ViewModels
{
    public class PaymentViewModel : ViewModelBase
    {
        private readonly IPaymentDao _paymentDao;
        private readonly INavigation _navigation;
        
        public ICommand PayCommand { get; }

        public ObservableCollection<PaymentModel> _paymentModels { get; set; }
        public PaymentViewModel(IPaymentDao paymentDao, INavigation navigation)
        {
            _paymentDao = paymentDao;          
            _navigation = navigation;
            _paymentModels = new ObservableCollection<PaymentModel>(paymentDao.GetAllPayment());
            PayCommand = new RelayCommand<List<CartItemModel>>(AddPayment);
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


        public async void AddPayment(List<CartItemModel> cartItems)
        {
            if (cartItems == null)
            {
                return;
            }
            var payment = new PaymentModel
            {
                Id = Guid.NewGuid(),
                CartItems = cartItems,
                TotalPrice = TotalPrice,
                Discount = Discount,
                PriceAfterDiscount = PriceAfterDiscount,
                AmountReceived = (decimal)AmountReceived,
                Change = Change,
                CreatedDate = DateTime.Now,
            };
            //Thực hiện cập nhật lại số lượng 
            //Chưa thực hiện được do sử dụng mockdata
            _paymentDao.AddPayment(payment);

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

        private void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            _navigation.NavigateTo(typeof(HomePage));
        }
    }
}
