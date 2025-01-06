using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
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
    public sealed partial class UpdatePromotion : Page
    {
        public UpdatePromotionViewModel ViewModel { get; private set; }

        public UpdatePromotion()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is PromotionModel promotion)
            {
                // Sử dụng DI để lấy các dependency cần thiết và khởi tạo ViewModel
                var dao = App.Current.Services.GetService<IPromotionDao>();
                var navigationService = App.Current.Services.GetService<INavigation>();

                ViewModel = new UpdatePromotionViewModel(dao, navigationService, promotion);
                DataContext = ViewModel; // Gắn ViewModel vào DataContext
            }
            base.OnNavigatedTo(e);
        }


    }
}
