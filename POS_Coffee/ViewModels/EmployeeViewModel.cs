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

        private string _search;
        public string SearchQuery
        {
            get => _search;
            set => SetProperty(ref _search, value);
        }
        private AccountModel _selectedEmployee;
        public AccountModel SelectedEmployee
        {
            get => _selectedEmployee;
            set => SetProperty(ref _selectedEmployee, value);
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

        private ObservableCollection<TimeKeppingModel> _timeKeppings;
        public ObservableCollection<TimeKeppingModel> TimeKeppings
        {
            get => _timeKeppings;
            set => SetProperty(ref _timeKeppings, value);
        }



        public ICommand SubmitAttendanceCommand { get; }
        public ICommand AddEmployeeCommand {  get; }
        public ICommand DeleteEmployeeCommand { get; }
        public ICommand SalaryListCommand { get; }
        public ICommand SearchButtonClickCommand { get; }
        public IAsyncRelayCommand LoadEmployeesCommand { get; }
        public EmployeeViewModel(IAccountDao dao, INavigation navigation)
        {
            _dao = dao;
            _navigation = navigation;
            LoadEmployeesCommand = new AsyncRelayCommand(LoadEmployees);
            SubmitAttendanceCommand = new Utilities.RelayCommand(() => AddAttendance());
            AddEmployeeCommand = new Utilities.RelayCommand(() => AddEmployee());
            DeleteEmployeeCommand = new Utilities.RelayCommand(() => DeleteEmployee());
            SalaryListCommand = new Utilities.RelayCommand(() => GetSalaryList());
            SearchButtonClickCommand = new Utilities.RelayCommand(() => GetEmployeesByName());
            LoadEmployeesCommand.Execute(null);
        }

        public void SetXamlRoot(XamlRoot xamlRoot)
        {
            _xamlRoot = xamlRoot;
        }

        public async Task LoadEmployees()
        {
            var employees = await _dao.getAllEmployee();
            var timeKeepings = await _dao.GetTimeKeppingModelById(LoginViewModel.id);
            TimeKeppings = new ObservableCollection<TimeKeppingModel>(timeKeepings);
            _employees = new ObservableCollection<AccountModel>(employees);
        }

        public async void GetEmployeesByName()
        {
            var employees = await _dao.GetEmployeesByName(SearchQuery);
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
                var existedTimeKeeping = await _dao.GetTimeKeppingModel(LoginViewModel.id, DateOnly.FromDateTime(WorkDate.DateTime));
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
                    var timeKeepings = await _dao.GetTimeKeppingModelById(LoginViewModel.id);
                    TimeKeppings = new ObservableCollection<TimeKeppingModel>(timeKeepings);
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

        public void AddEmployee()
        {
            _navigation.NavigateTo(typeof(AddEmployeePage));
        }

        public void GetSalaryList()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var salaryList = _dao.GetSalaryByMonth(month, year);
            _navigation.NavigateTo(typeof(SalaryListPage), salaryList);
        }

        public async void DeleteEmployee()
        {
            SelectedEmployee = await _dao.RemoveEmployee(SelectedEmployee);
            if (SelectedEmployee != null)
            {
                var dialog = new ContentDialog()
                {
                    XamlRoot = _xamlRoot,
                    Content = "Xóa thành công",
                    Title = "Thành công",
                    CloseButtonText = "OK",
                };
                await dialog.ShowAsync();
                var employees = await _dao.getAllEmployee();
                _employees = new ObservableCollection<AccountModel>(employees);
            }
            else
            {
                var dialog = new ContentDialog()
                {
                    XamlRoot = _xamlRoot,
                    Content = "Xóa thất bại",
                    Title = "Thất bại",
                    CloseButtonText = "OK",
                };
                await dialog.ShowAsync();
            }
        }

    }
}
