﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Utilities
{
    public interface INavigation
    {
        void NavigateTo(Type pageType);
        void NavigateTo(Type pageType, object parameter);
        void GoBack();
    }
}
