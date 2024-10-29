using POS_Coffee.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POS_Coffee.ViewModels
{
    public class MainViewModel 
    {
        private readonly INavigation _navigation;
        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }
        

    }
}
