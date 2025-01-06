using ABI.System;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DateTimeOffset = System.DateTimeOffset;
using TimeSpan = System.TimeSpan;

namespace POS_Coffee.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly IAccountDao _dao;
        private readonly INavigation _navigation;
        public ObservableCollection<AccountModel> _employees { get; set; }

        private AccountModel _emp;
        public AccountModel NewEmp {
            get => _emp;
            set => SetProperty(ref _emp, value);
        }
        private XamlRoot _xamlRoot;
        private DateTimeOffset _workDate = DateTimeOffset.Now;
        public DateTimeOffset WorkDate
        {
            get => _workDate;
            set => SetProperty(ref _workDate, value);
        }

        private TimeSpan _startTime;
        public TimeSpan StartTime
        {
            get => _startTime;
            set
            {
                if (SetProperty(ref _startTime, value))
                {
                    CalculateHours();
                }
            }
        }

        private TimeSpan _endTime;
        public TimeSpan EndTime
        {
            get => _endTime;
            set 
            {
                if (SetProperty(ref _endTime, value))
                {
                    CalculateHours();
                }
            } 
        }

        private float _hours;
        public float Hours
        {
            get => _hours;
            set => SetProperty(ref _hours, value);
        }

        

        public ICommand SubmitAttendanceCommand { get; }
        public ICommand AddEmployeeCommand {  get; }
        public ICommand SalaryListCommand { get; }
        public IAsyncRelayCommand LoadEmployeesCommand { get; }
        public EmployeeViewModel(IAccountDao dao, INavigation navigation)
        {
            _dao = dao;
            _navigation = navigation;
            LoadEmployeesCommand = new AsyncRelayCommand(LoadEmployees);
            SubmitAttendanceCommand = new Utilities.RelayCommand(() => AddAttendance());
            AddEmployeeCommand = new Utilities.RelayCommand(() => AddEmployee());
            SalaryListCommand = new Utilities.RelayCommand(() => GetSalaryList());
            LoadEmployeesCommand.Execute(null);
        }

        public void SetXamlRoot(XamlRoot xamlRoot)
        {
            _xamlRoot = xamlRoot;
        }

        public async Task LoadEmployees()
        {
            var employees = await _dao.getAllEmployee();
            _employees = new ObservableCollection<AccountModel>(employees);
        }

        private void CalculateHours()
        {
            var duration = EndTime - StartTime;
            Hours = (float)duration.TotalHours;
        }

        public async void AddAttendance()
        {
            if (Hours <= 0)
            {
                var failDialog = new ContentDialog()
                {
                    XamlRoot = _xamlRoot,
                    Content = "Giờ làm việc không hợp lệ",
                    Title = "Thất bại",
                    CloseButtonText = "OK",
                };
                await failDialog.ShowAsync();
            }
            else
            {
                var existedTimeKeeping = _dao.GetTimeKeppingModel(LoginViewModel.id, DateOnly.FromDateTime(WorkDate.DateTime));
                if (existedTimeKeeping != null)
                {
                    var failDialog = new ContentDialog()
                    {
                        XamlRoot = _xamlRoot,
                        Content = "Bạn đã thực hiện chấm công trong ngày",
                        Title = "Thất bại",
                        CloseButtonText = "OK",
                    };
                    await failDialog.ShowAsync();
                }
                else
                {
                    var timeKeeping = new TimeKeppingModel
                    {
                        EmployeeID = LoginViewModel.id,
                        WorkDate = DateOnly.FromDateTime(WorkDate.DateTime),
                        StartTime = TimeOnly.FromTimeSpan(StartTime),
                        EndTime = TimeOnly.FromTimeSpan(EndTime),
                        Hours = Hours,
                    };
                    await _dao.AddTimeKepping(timeKeeping);
                    var dialog = new ContentDialog()
                    {
                        XamlRoot = _xamlRoot,
                        Content = "Chấm công thành công",
                        Title = "Thành công",
                        CloseButtonText = "OK",
                    };
                    await dialog.ShowAsync();
                }
            }
        }

        public async void AddEmployee()
        {
            NewEmp = new AccountModel();
            var dialog = new AddEmployeeDialog
            {
                XamlRoot = _xamlRoot,
                AddedEmp = NewEmp
            };
            dialog.PrimaryButtonClick += AddEmployeeDialog_PrimaryButtonClick;
            await dialog.ShowAsync();
            NewEmp = dialog.AddedEmp;
        }

        private async void AddEmployeeDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            NewEmp.role = "employee";
            if (NewEmp == null || string.IsNullOrWhiteSpace(NewEmp.name))
            {
                Debug.WriteLine("Tên không đc để trống");
            }
            else
            {
                await _dao.AddEmployee(NewEmp);
                var employees = await _dao.getAllEmployee();
                _employees = new ObservableCollection<AccountModel>(employees);
            }           
        }

        public void GetSalaryList()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var salaryList = _dao.GetSalaryByMonth(month, year);
            _navigation.NavigateTo(typeof(SalaryListPage), salaryList);
        }
    }
}
