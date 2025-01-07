using Microsoft.UI.Xaml.Controls;
using POS_Coffee.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Coffee.Utilities;
using POS_Coffee.Models;
using POS_Coffee.Views;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using RelayCommand = POS_Coffee.Utilities.RelayCommand;

namespace POS_Coffee.ViewModels
{
    public class MembersViewModel : ViewModelBase
    {
        private readonly IMembersDao _membersDao;
        //private readonly INavigation _navigation;

        public ObservableCollection<MembersModel> Members { get; set; } = new ObservableCollection<MembersModel>();

        public ICommand AddNewMemberCommand { get; }
        public MembersViewModel(IMembersDao membersDao, INavigation navigation)
        {
            _membersDao = membersDao;
            //_navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
            LoadMembers();
            AddNewMemberCommand = new RelayCommand(AddNewMember);
        }


        private string _customerName;
        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                OnPropertyChanged();
            }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }
        private int _point;
        public int Point
        {
            get => _point;
            set
            {
                _point = value;
                OnPropertyChanged();
            }
        }
        private async void LoadMembers()
        {
            try
            {
                var members = await _membersDao.GetAllMembers();
                Members.Clear(); // Clear any existing data
                foreach (var member in members)
                {
                    Members.Add(member);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading members: {ex.Message}");
            }
        }

        public async void AddNewMember()
        {
            if (!string.IsNullOrEmpty(CustomerName) && !string.IsNullOrEmpty(PhoneNumber) && Point >= 0)
            {
                var newMember = new MembersModel
                {
                    Name = CustomerName,
                    phoneNumber = PhoneNumber,
                    point = 0
                };

                await _membersDao.AddMember(newMember);

                Members.Add(newMember);

                CustomerName = string.Empty;
                PhoneNumber = string.Empty;
                Point = 0;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid input, cannot add new member.");
            }
        }
    }
}