using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.Views;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Payments;

namespace POS_Coffee.ViewModels
{
    public class SalaryViewModel : ViewModelBase
    {
        private readonly IAccountDao _dao;
        private readonly INavigation _navigation;
        private XamlRoot _xamlRoot;
        private ObservableCollection<SalaryDTO> _salaryList = new ObservableCollection<SalaryDTO>();
        public ObservableCollection<SalaryDTO> SalaryList
        {
            get => _salaryList;
            set => SetProperty(ref _salaryList, value);
        }

        private int _month = DateTime.Now.Month;
        public int SelectedMonth
        {
            get => _month;
            set => SetProperty(ref _month, value);
        }

        private int _year = DateTime.Now.Year;
        public int SelectedYear
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }

        public void SetXamlRoot(XamlRoot xamlRoot)
        {
            _xamlRoot = xamlRoot;
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

        private async void PrintSalaryList()
        {
            try
            {
                var report = new StiReport();
                report.Load("D:/Window Programing/Project/POS_Coffee/POS_Coffee/Reports/SalaryReport.mrt");
                report.Dictionary.Variables["Month"].Value = SelectedMonth.ToString();
                report.Dictionary.Variables["Year"].Value = SelectedYear.ToString();
                report.Compile();
                report.Render();
                //report.Show();
                var pdfFilePath = Path.Combine("D:/Window Programing/Project/POS_Coffee/POS_Coffee", "PDFs", "SalaryReport_" + SelectedMonth + "_" + SelectedYear + ".pdf");
                //var pdfExport = new StiPdfExportService();
                report.ExportDocument(StiExportFormat.Pdf, pdfFilePath);
                var dialog = new ContentDialog()
                {
                    XamlRoot = _xamlRoot,
                    Content = "In thành công",
                    Title = "Thành công",
                    CloseButtonText = "OK",
                };
                await dialog.ShowAsync();
            }
            catch (Exception ex)
            {
                var dialog = new ContentDialog()
                {
                    XamlRoot = _xamlRoot,
                    Content = "In thất bại",
                    Title = "Thất bại",
                    CloseButtonText = "OK",
                };
                await dialog.ShowAsync();
            }
        }

    }
}
