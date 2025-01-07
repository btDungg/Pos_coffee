using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POS_Coffee.ViewModels
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        private readonly IAccountDao _dao;
        private readonly INavigation _navigation;
        //
        private string _nameErrorMessage;
        public string NameErrorMessage
        {
            get => _nameErrorMessage;
            set => SetProperty(ref _nameErrorMessage, value);
        }
        
        private string _nameErrorVisible;
        public string NameErrorVisible
        {
            get => _nameErrorVisible;
            set => SetProperty(ref _nameErrorVisible, value);
        }
        //
        private string _addressErrorMessage;
        public string AddressErrorMessage
        {
            get => _addressErrorMessage;
            set => SetProperty(ref _addressErrorMessage, value);
        }

        private string _addressErrorVisible;
        public string AddressErrorVisible
        {
            get => _addressErrorVisible;
            set => SetProperty(ref _addressErrorVisible, value);
        }
        //
        private string _emailErrorMessage;
        public string EmailErrorMessage
        {
            get => _emailErrorMessage;
            set => SetProperty(ref _emailErrorMessage, value);
        }
        
        private string _emailErrorVisible;
        public string EmailErrorVisible
        {
            get => _emailErrorVisible;
            set => SetProperty(ref _emailErrorVisible, value);
        }
        //
        private string _phoneErrorMessage;
        public string PhoneErrorMessage
        {
            get => _phoneErrorMessage;
            set => SetProperty(ref _phoneErrorMessage, value);
        }

        private string _phoneErrorVisible;
        public string PhoneErrorVisible
        {
            get => _phoneErrorVisible;
            set => SetProperty(ref _phoneErrorVisible, value);
        }
        //
        private string _usernameErrorMessage;
        public string UsernameErrorMessage
        {
            get => _usernameErrorMessage;
            set => SetProperty(ref _usernameErrorMessage, value);
        }

        private string _usernameErrorVisible;
        public string UsernameErrorVisible
        {
            get => _usernameErrorVisible;
            set => SetProperty(ref _usernameErrorVisible, value);
        }
        //
        private string _passwordErrorMessage;
        public string PasswordErrorMessage
        {
            get => _phoneErrorMessage;
            set => SetProperty(ref _phoneErrorMessage, value);
        }

        private string _passwordErrorVisible;
        public string PasswordErrorVisible
        {
            get => _passwordErrorVisible;
            set => SetProperty(ref _passwordErrorVisible, value);
        }
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _address;
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string _phone;
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand CancelCommand { get; }
        public ICommand AddCommand { get; }
        private XamlRoot _xamlRoot;
        public AddEmployeeViewModel(IAccountDao dao, INavigation navigation)
        {
            _navigation = navigation;
            _dao = dao;
            CancelCommand = new RelayCommand(Cancel);
            AddCommand = new RelayCommand(AddEmployee);
        }

        public void SetXamlRoot(XamlRoot xamlRoot)
        {
            _xamlRoot = xamlRoot;
        }

        private void Cancel()
        {
            _navigation.NavigateTo(typeof(EmployeeManagementPage));
        }

        private async void AddEmployee()
        {
            var check = true;
            //check name
            if (string.IsNullOrWhiteSpace(Name))
            {
                NameErrorMessage = "Tên không được để trống";
                NameErrorVisible = "Visible";
                check = false;
            }
            else
            {
                NameErrorVisible = "Collapsed";
            }
            // check address
            if (string.IsNullOrWhiteSpace(Address))
            {
                AddressErrorMessage = "Địa chỉ không được để trống";
                AddressErrorVisible = "Visible";
                check = false;
            }
            else
            {
                AddressErrorVisible = "Collapsed";
            }
            //check phone
            if (string.IsNullOrWhiteSpace(Phone))
            {
                PhoneErrorMessage = "Số điện thoại không được để trống";
                PhoneErrorVisible = "Visible";
                check = false;
            }
            else
            {
                Regex regexPhoneNumber = new Regex(@"^(0[3|5|7|8|9])[0-9]{8}$");
                if (regexPhoneNumber.IsMatch(Phone) == false)
                {
                    PhoneErrorMessage = "Số điện thoại không hợp lệ";
                    PhoneErrorVisible = "Visible";
                    check = false;
                }
                else
                {
                    PhoneErrorVisible = "Collapsed";
                }
            }
            //check email
            if (string.IsNullOrWhiteSpace(Email))
            {
                EmailErrorMessage = "Email không được để trống";
                EmailErrorVisible = "Visible";
                check = false;
            }
            else
            {
                Regex regexEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
                if (regexEmail.IsMatch(Email) == false)
                {
                    EmailErrorMessage = "Email không hợp lệ";
                    EmailErrorVisible = "Visible";
                    check = false;
                }
                else
                {
                    EmailErrorVisible = "Collapsed";
                }
            }
            //check username
            if (string.IsNullOrWhiteSpace(Username))
            {
                UsernameErrorMessage = "Tên đăng nhập không được để trống";
                UsernameErrorVisible = "Visible";
                check = false;
            }
            else
            {
                var account = await _dao.getAccountByUsername(Username);
                if (account != null)
                {
                    UsernameErrorMessage = "Tên đăng nhập đã được sử dụng";
                    UsernameErrorVisible = "Visible";
                    check = false;
                }
                else
                {
                    UsernameErrorVisible = "Collapsed";
                }
            }
            //check password
            if (string.IsNullOrWhiteSpace(Password))
            {
                PasswordErrorMessage = "Mật khẩu không được để trống";
                PasswordErrorVisible = "Visible";
                check = false;
            }
            else
            {
                PasswordErrorVisible = "Collapsed";
            }

            //add employee
            if (check == true)
            {
                var employee = new AccountModel
                {
                    name = Name,
                    email = Email,
                    password = Password,
                    username = Username,
                    phone = Phone,
                    address = Address,
                    role = "employee",
                    isActive = true
                };
                employee = await _dao.AddEmployee(employee);
                if (employee != null)
                {
                    var dialog = new ContentDialog()
                    {
                        XamlRoot = _xamlRoot,
                        Content = "Thêm thành công",
                        Title = "Thành công",
                        PrimaryButtonText = "OK",
                    };
                    dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;
                    await dialog.ShowAsync();
                }
            }
            
        }

        private void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            _navigation.NavigateTo(typeof(EmployeeManagementPage));
        }
    }
}
