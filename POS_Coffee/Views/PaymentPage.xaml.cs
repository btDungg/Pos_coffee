using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using POS_Coffee.Models;
using POS_Coffee.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace POS_Coffee.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PaymentPage : Page
    {
        public PaymentPage()
        {
            this.InitializeComponent();
            this.Loaded += PaymentPage_Loaded;
        }

        private void PaymentPage_Loaded(object sender, RoutedEventArgs e)
        {
            PaymentViewModel.SetXamlRoot(this.XamlRoot);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is CartItemViewModel cartItemViewModel)
            {
                List<CartItemModel> cartItems = new List<CartItemModel>();
                PaymentViewModel.TotalPrice = cartItemViewModel.TotalPrice;
                foreach(var item in cartItemViewModel.CartItems)
                {
                    cartItems.Add(item);
                }
                var CartItemViewModel = new
                {
                    CartItems = cartItems,
                    TotalPrice = cartItemViewModel.TotalPrice,
                };
                DataContext = CartItemViewModel;
            }
        }
        public PaymentViewModel PaymentViewModel { get; set; }
            = App.Current.Services.GetService<PaymentViewModel>();

        //public CartItemViewModel CartItemViewModel { get; set; }
        //    = App.Current.Services.GetService<CartItemViewModel>();
    }
 }
