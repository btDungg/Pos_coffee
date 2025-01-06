using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using POS_Coffee.Utilities;
using POS_Coffee.ViewModels;
using POS_Coffee.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;
using WinRT.Interop;
using Windows.Storage;
using Windows.Storage.Pickers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace POS_Coffee
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            nvSample.ItemInvoked += OnItemInvoked;
            ViewModel.NavigationCompleted += OnNavigationCompleted;
            LoginViewModel.OnLoginSuccess += ShowNavigationItems;
            SetWindowSize(this, 1300, 825);
            CenterWindowOnScreen(this);
            DisableWindowResize(this);
            this.Title = "Quản lý bán hàng";
            mainFrame.Content = new LoginPage();
            HideNavigationItems();
        }

        private void HideNavigationItems()
        {
            foreach (var item in nvSample.MenuItems)
            {
                if (item is NavigationViewItem navItem)
                {
                    navItem.Visibility = Visibility.Collapsed;
                    //navItem.IsEnabled = false;
                }
            }
            foreach (var item in nvSample.FooterMenuItems)
            {
                if (item is NavigationViewItem navItem)
                {
                    navItem.Visibility = Visibility.Collapsed;
                    //navItem.IsEnabled = false;
                }
            }
        }

        private void ShowNavigationItems(string role)
        {
            foreach (var item in nvSample.MenuItems)
            {
                if (item is NavigationViewItem navItem)
                {
                    if((navItem.Name == "HomePage" || navItem.Name == "PaymentPage" || navItem.Name == "TimeKeepingPage"|| navItem.Name== "MembersManagement") && role == "employee")
                    {
                        navItem.Visibility = Visibility.Visible;
                    }
                    if ((navItem.Name == "StockManagement" || navItem.Name == "PaymentPage" 
                        || navItem.Name == "FinancialReport" || navItem.Name == "PromotionManagement"
                        || navItem.Name == "EmployeeManagement"
                        || navItem.Name == "MembersManagement")
                        && role == "admin")
                    {
                        navItem.Visibility = Visibility.Visible;
                    }
                    //navItem.IsEnabled = true;
                }
            }
            foreach (var item in nvSample.FooterMenuItems)
            {
                if (item is NavigationViewItem navItem)
                {
                    //navItem.IsEnabled = true;
                   navItem.Visibility = Visibility.Visible;
                }
            }
           
        }

        private void OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer is NavigationViewItem item)
            {
                string pageKey = item.Name;
                ViewModel.NavigateCommand.Execute(pageKey);
            }
        }

        private void OnNavigationCompleted(string pageName)
        {
            bool isLoginPage = pageName == "LogOut";  

            foreach (var item in nvSample.MenuItems)
            {
                if (item is NavigationViewItem navItem)
                {
                    if (isLoginPage == true)
                    {
                        navItem.Visibility = Visibility.Collapsed;
                    }
                }
            }
            foreach (var item in nvSample.FooterMenuItems)
            {
                if (item is NavigationViewItem navItem)
                {
                    if (isLoginPage == true)
                    {
                        navItem.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        public Frame MainFrame => mainFrame;

        public MainViewModel ViewModel { get; }
            = App.Current.Services.GetService<MainViewModel>();
        public LoginViewModel LoginViewModel { get; }
            = App.Current.Services.GetService<LoginViewModel>();

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            var hwnd = WindowNative.GetWindowHandle(this);
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);
            appWindow.Hide();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void SetWindowSize(Window window, int width, int height)
        {
            var hwnd = WindowNative.GetWindowHandle(window);
            var dpi = GetDpiForWindow(hwnd) / 96.0;
            var adjustedWidth = (int)(width * dpi);
            var adjustedHeight = (int)(height * dpi);

            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new SizeInt32(adjustedWidth, adjustedHeight));
        }
        [DllImport("User32.dll")]
        private static extern int GetDpiForWindow(IntPtr hwnd);

        private void CenterWindowOnScreen(Window window)
        {
            var hwnd = WindowNative.GetWindowHandle(window);
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);
            var displayArea = DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Primary);
            var centeredPosition = new PointInt32(
                (displayArea.WorkArea.Width - appWindow.Size.Width) / 2,
                (displayArea.WorkArea.Height - appWindow.Size.Height) / 2
            );
            appWindow.Move(centeredPosition);
        }


        private void DisableWindowResize(Window window)
        {
            var hwnd = WindowNative.GetWindowHandle(window);
            var style = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, style & ~WS_SIZEBOX);
        }

        [DllImport("User32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("User32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;
        private const int WS_SIZEBOX = 0x00040000;
    }

}
