using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Utilities
{
    class NavigationService : INavigation
    {
        public static Frame _frame => App.mainWindow.MainFrame;

        public void GoBack()
        {
            if (_frame.CanGoBack)
                _frame.GoBack();
        }

        public void NavigateTo(Type pageType)
        {
            NavigateTo(pageType, null);
        }

        public void NavigateTo(Type pageType, object parameter)
        {
            _frame.Navigate(pageType, parameter);
        }
    }
}
