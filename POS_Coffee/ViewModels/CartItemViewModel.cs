using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.ViewModels
{
    public class CartItemViewModel : ViewModelBase
    {
        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }
        

        public CartItemModel CartItem { get; }

        public CartItemViewModel(CartItemModel cartItem)
        {
            CartItem = cartItem;
            Quantity = cartItem.Quantity; // Khởi tạo Quantity từ CartItemModel
            Price = Quantity * CartItem.Price; // Tính TotalPrice từ Quantity và Price
        }
    }
}
