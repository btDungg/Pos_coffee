using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POS_Coffee.ViewModels
{
    public class SalaryViewModel : ViewModelBase
    {
        private readonly IAccountDao _dao;
        private readonly INavigation _navigation;

        private ObservableCollection<SalaryDTO> _salaryList = new ObservableCollection<SalaryDTO>();
        public ObservableCollection<SalaryDTO> SalaryList
        {
            get => _salaryList;
            set => SetProperty(ref _salaryList, value);
        }

        private int _month;
        public int SelectedMonth
        {
            get => _month;
            set => SetProperty(ref _month, value);
        }

        private int _year;
        public int SelectedYear
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }
        public List<int> Months { get; } = Enumerable.Range(1, 12).ToList();
        public List<int> Years { get; } = new List<int> { 2023, 2024, 2025, 2026, 2027 };

        public ICommand GetSalaryListCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand PrintSalaryListCommand { get; }
        public SalaryViewModel(IAccountDao dao, INavigation navigation)
        {
            _dao = dao;
            _navigation = navigation;
            GetSalaryListCommand = new RelayCommand(GetSalaryList);
            BackCommand = new RelayCommand(BackToEmp);
            PrintSalaryListCommand = new RelayCommand(PrintSalaryList);
        }

        private void GetSalaryList()
        {
            var salaryList = _dao.GetSalaryByMonth(SelectedMonth, SelectedYear);
            SalaryList = new ObservableCollection<SalaryDTO>(salaryList);
        }

        private void BackToEmp()
        {
            _navigation.NavigateTo(typeof(EmployeeManagementPage));
        }

        private void PrintSalaryList()
        {

        }

    }
}
