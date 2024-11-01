using Microsoft.UI.Xaml.Navigation;
using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.ViewModels
{
    public class PaymentViewModel : ViewModelBase
    {
        public ObservableCollection<CartItemModel> CartItems { get; set; } = new ObservableCollection<CartItemModel>();
        public decimal TotalPrice { get; set; }


        public PaymentViewModel(ObservableCollection<CartItemModel> cartItems, decimal totalPrice)
        {
            CartItems = cartItems;
            TotalPrice = totalPrice;
        }
        public PaymentViewModel(ObservableCollection<CartItemModel> cartItems)
        {
            CartItems = cartItems;
        }

       
    }
}
