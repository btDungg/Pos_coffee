using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
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
    public class CartItemViewModel : ViewModelBase
    {
        private readonly INavigation _navigation;
        private readonly IFoodDao _dao;
        private ObservableCollection<CartItemModel> _cartItems = new ObservableCollection<CartItemModel>();
        public ObservableCollection<CartItemModel> CartItems
        {
            get => _cartItems;
            set => SetProperty(ref _cartItems, value);
        }
 
        private decimal _totalPrice = 0;
        public decimal TotalPrice
        {
            get => _totalPrice;
            set => SetProperty(ref _totalPrice, value);
        }
        public ICommand SelectFoodCommand { get; }
        public ICommand IncreaseQuantityCommand { get; }
        public ICommand DecreaseQuantityCommand { get; }
        public ICommand NavigateToPaymentCommand {  get; }
        public ICommand RemoveItemCommand { get; }



        public CartItemViewModel(INavigation navigation, IFoodDao dao)
        {
            _navigation = navigation;
            _dao = dao;
            SelectFoodCommand = new CommunityToolkit.Mvvm.Input.RelayCommand<FoodModel>(SelectFood_Click);
            IncreaseQuantityCommand = new CommunityToolkit.Mvvm.Input.RelayCommand<CartItemModel>(IncreaseQuantity);
            DecreaseQuantityCommand = new CommunityToolkit.Mvvm.Input.RelayCommand<CartItemModel>(DecreaseQuantity);
            NavigateToPaymentCommand = new RelayCommand(() => NavigateToPaymentPage());
            RemoveItemCommand = new CommunityToolkit.Mvvm.Input.RelayCommand<CartItemModel>(RemoveItem);
        }

        private async void SelectFood_Click(FoodModel selectedFood)
        {
            if (selectedFood != null)
            {
                var SelectedItem = CartItems.FirstOrDefault(item => item.Id == selectedFood.Id);
                
                if (SelectedItem != null)
                {
                    var qnt = await _dao.GetQuantityById(SelectedItem.Id);
                    if (SelectedItem.Quantity < qnt)
                    {
                        // Tăng số lượng nếu sản phẩm đã có trong giỏ hàng
                        SelectedItem.Quantity += 1;
                        TotalPrice += selectedFood.Price;
                    }                 
                }
                else
                {
                    // Thêm sản phẩm mới vào giỏ hàng nếu chưa tồn tại
                    SelectedItem = new CartItemModel
                    {
                        Id = selectedFood.Id,
                        Name = selectedFood.Name,
                        Description = selectedFood.Description,
                        Note = "",
                        Price = selectedFood.Price,
                        Quantity = 1,
                        Image = selectedFood.Image,
                        Category = selectedFood.Category
                    };
                    CartItems.Add(SelectedItem);
                    TotalPrice += selectedFood.Price;
                }
            }
        }

        private async void IncreaseQuantity(CartItemModel item)
        {
            if (item != null)
            {
                var qnt = await _dao.GetQuantityById(item.Id);
                if (item.Quantity < qnt)
                {
                    item.Quantity += 1;
                    TotalPrice += item.Price;
                }
            }
        }

        private void DecreaseQuantity(CartItemModel item)
        {
            if (item != null && item.Quantity > 1)
            {
                item.Quantity -= 1;
                TotalPrice -= item.Price;
            }
        }

        private void NavigateToPaymentPage()
        {
            if (CartItems.Count > 0)
            {
                _navigation.NavigateTo(typeof(PaymentPage), this);
            }
            else
            {
                // Thông báo rằng giỏ hàng trống nếu không có sản phẩm
            }
        }

        private void RemoveItem(CartItemModel item)
        {
            if (item != null && CartItems.Contains(item))
            {
                CartItems.Remove(item);
                TotalPrice -= item.Price * item.Quantity;
            }
        }
    }
}
