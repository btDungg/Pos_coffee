﻿using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using POS_Coffee.Utilities;
using POS_Coffee.Views;
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
            NavigateCommand = new RelayCommand<string>(Navigate);
        }

        public ICommand NavigateCommand { get; }

        private void Navigate(string pageName)
        {
            switch (pageName)
            {
                case "HomePage":
                    _navigation.NavigateTo(typeof(HomePage));
                    break;
                case "LoginPage":
                    _navigation.NavigateTo(typeof(LoginPage));
                    break;
                case "PaymentPage":
                    _navigation.NavigateTo(typeof(PaymentManagementPage));
                    break;
            }
        }

    }
}
