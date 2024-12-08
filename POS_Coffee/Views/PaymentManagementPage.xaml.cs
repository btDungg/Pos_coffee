using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;
using POS_Coffee.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace POS_Coffee.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PaymentManagementPage : Page
    {
        public PaymentManagementPage()
        {
            this.InitializeComponent();
            this.Loaded += PaymentPage_Loaded;
        }

        private void PaymentPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.SetXamlRoot(this.XamlRoot);
        }

        public PaymentViewModel ViewModel { get; set; }
            = App.Current.Services.GetService<PaymentViewModel>();
    }
}
