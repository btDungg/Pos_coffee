﻿using POS_Coffee.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using POS_Coffee.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;
using POS_Coffee.Models;
using System.Windows.Input;
using POS_Coffee.Repositories;

namespace POS_Coffee.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public event Action<string> OnLoginSuccess; 
        private readonly INavigation _navigation;
        private readonly IAccountDao _accountDao;
        public static string username {  get; private set; }
        public static int id { get; private set; }
        private string _username;
        private string _password;
        public string ErrorMessage { get; set; }
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        // Command để xử lý đăng nhập
        public ICommand LoginCommand { get; }

        public LoginViewModel(INavigation navigation, IAccountDao accountDao)
        {
            _accountDao = accountDao;
            _navigation = navigation;
            LoginCommand = new RelayCommand(() => Login());
        }



        private async void Login()
        {
            var user = await _accountDao.getAccountByUsername(Username);
            if (user == null)
            {
                ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            else
            {
                if (user.password != Password)
                {
                    ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
                else
                {
                    id = user.Id;
                    username = user.name;

                    // Điều hướng dựa trên vai trò của người dùng
                    if (user.role == "employee")
                    {
                        _navigation.NavigateTo(typeof(HomePage), user);
                    }
                    else if (user.role == "admin")
                    {
                        _navigation.NavigateTo(typeof(StockManagementPage), user);
                    }

                    OnLoginSuccess?.Invoke(user.role);
                }
            }
        }
    }
}
