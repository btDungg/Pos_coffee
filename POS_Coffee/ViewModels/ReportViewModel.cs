using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
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
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace POS_Coffee.ViewModels
{
    public class ReportViewModel : ViewModelBase
    {
        public class GroupedStock
        {
            public string Name { get; set; }
            public int TotalStockNumber { get; set; }
            public List<StockModel> ReportStocks { get; set; }
        }

        public class ReportTest
        { 
            public Guid Id { get; set; }
            public string PaymentDate { get; set; }
            public decimal TotalPrice { get; set; }
            public decimal TotalFoodPrice { get; set; }
            public decimal TotalDrinkPrice { get; set; }
            public int SortPayment { get; set; }
            public DateTime CreatedDate { get; set; }
        }

        //Variable
        private readonly IStockDAO _daoStock;
        private readonly IPaymentDao _daoPayment;
        private readonly IPaymentDetailDao _daoPaymentDetail;
        private readonly IFoodDao _daoFood;
        private INavigation _navigation;
        private XamlRoot _xamlRoot;
        
        private ObservableCollection<ReportTest> _report;
        public ObservableCollection<ReportTest> Report
        {
            get => _report;
            set => SetProperty(ref _report, value);
        }

        // Cần thêm biến:
        public ObservableCollection<PaymentModel> Payments { get; set; }
        public ObservableCollection<PaymentDetailModel> PaymentsDetail { get; set; }
        public ObservableCollection<FoodModel> Foods { get; set; }

        public ICommand YearReportClickCmd { get; }
        public ICommand QuarterReportClickCmd { get; }
        public ICommand MonthReportClickCmd { get; }
        public ICommand DayReportClickCmd { get; }

        public ReportViewModel(IStockDAO stockDAO, IPaymentDao paymentDao, IFoodDao foodDao, IPaymentDetailDao paymentDetailDao ,INavigation navigation)
        {
            _daoStock = stockDAO;
            _daoPayment = paymentDao;
            _daoFood = foodDao;
            _daoPaymentDetail = paymentDetailDao;
            _navigation = navigation;
            YearReportClickCmd = new AsyncRelayCommand(YearReportClick);
            QuarterReportClickCmd = new AsyncRelayCommand(QuarterReportClick);
            MonthReportClickCmd = new AsyncRelayCommand(MonthReportClick);
            DayReportClickCmd = new AsyncRelayCommand(DayReportClick);
        }

        private async Task YearReportClick()
        {
            // Get all  payments
            var payments = await _daoPayment.GetAllPayment();
            Payments = new ObservableCollection<PaymentModel>(payments);
            // Get all foods
            var foods = await _daoFood.GetAllFood("");
            Foods = new ObservableCollection<FoodModel>(foods);
            // Get all payment details
            var paymentsDetail = await _daoPaymentDetail.GetAllPaymentDetail();
            PaymentsDetail = new ObservableCollection<PaymentDetailModel>(paymentsDetail);

            // Query
            var result = from p in Payments // Giả sử `payments` là danh sách Payments
                         join pd in PaymentsDetail on p.Id equals pd.PaymentID // Kết nối PaymentDetails
                         join f in Foods on pd.FoodId equals f.Id // Kết nối Foods
                         group new { pd, f } by new { PaymentYear = p.CreatedDate.Year } into g // Nhóm theo Id, CreatedDate và Category
                         select new ReportTest
                         {
                             TotalFoodPrice = g.Sum(item => item.f.Category == "Đồ ăn" ? item.pd.Quantity * item.f.Price : 0), // Tính tổng giá cho Đồ ăn
                             TotalDrinkPrice = g.Sum(item => item.f.Category == "Đồ uống" ? item.pd.Quantity * item.f.Price : 0), // Tính tổng giá cho Đồ uống
                             SortPayment = g.Key.PaymentYear,
                             PaymentDate = g.Key.PaymentYear.ToString()
                         } into groupedResult // Đưa kết quả vào biến tạm
                         orderby groupedResult.SortPayment ascending // Sắp xếp theo CreatedDate tăng dần
                         select groupedResult; // Chọn kết quả đã sắp xếp

            Report = new ObservableCollection<ReportTest>(result);
        }

        private async Task QuarterReportClick()
        {
            // Get all  payments
            var payments = await _daoPayment.GetAllPayment();
            Payments = new ObservableCollection<PaymentModel>(payments);
            // Get all foods
            var foods = await _daoFood.GetAllFood("");
            Foods = new ObservableCollection<FoodModel>(foods);
            // Get all payment details
            var paymentsDetail = await _daoPaymentDetail.GetAllPaymentDetail();
            PaymentsDetail = new ObservableCollection<PaymentDetailModel>(paymentsDetail);

            // Query
            var result = from p in Payments // Giả sử `payments` là danh sách Payments
                         join pd in PaymentsDetail on p.Id equals pd.PaymentID // Kết nối PaymentDetails
                         join f in Foods on pd.FoodId equals f.Id // Kết nối Foods
                         group new { pd, f } by new { PaymentQuarter = (p.CreatedDate.Month - 1) / 3 + 1 } into g // Nhóm theo Id, CreatedDate và Category
                         select new ReportTest
                         {
                             TotalFoodPrice = g.Sum(item => item.f.Category == "Đồ ăn" ? item.pd.Quantity * item.f.Price : 0), // Tính tổng giá cho Đồ ăn
                             TotalDrinkPrice = g.Sum(item => item.f.Category == "Đồ uống" ? item.pd.Quantity * item.f.Price : 0), // Tính tổng giá cho Đồ uống
                             SortPayment = g.Key.PaymentQuarter,
                             PaymentDate = g.Key.PaymentQuarter.ToString()
                         } into groupedResult // Đưa kết quả vào biến tạm
                         orderby groupedResult.SortPayment ascending // Sắp xếp theo CreatedDate tăng dần
                         select groupedResult; // Chọn kết quả đã sắp xếp

            Report = new ObservableCollection<ReportTest>(result);
        }

        private async Task MonthReportClick()
        {
            // Get all  payments
            var payments = await _daoPayment.GetAllPayment();
            Payments = new ObservableCollection<PaymentModel>(payments);
            // Get all foods
            var foods = await _daoFood.GetAllFood("");
            Foods = new ObservableCollection<FoodModel>(foods);
            // Get all payment details
            var paymentsDetail = await _daoPaymentDetail.GetAllPaymentDetail();
            PaymentsDetail = new ObservableCollection<PaymentDetailModel>(paymentsDetail);

            // Query
            var result = from p in Payments // Giả sử `payments` là danh sách Payments
                         join pd in PaymentsDetail on p.Id equals pd.PaymentID // Kết nối PaymentDetails
                         join f in Foods on pd.FoodId equals f.Id // Kết nối Foods
                         group new { pd, f } by new { PaymentMonth = p.CreatedDate.Month } into g // Nhóm theo Id, CreatedDate và Category
                         select new ReportTest
                         {
                             TotalFoodPrice = g.Sum(item => item.f.Category == "Đồ ăn" ? item.pd.Quantity * item.f.Price : 0), // Tính tổng giá cho Đồ ăn
                             TotalDrinkPrice = g.Sum(item => item.f.Category == "Đồ uống" ? item.pd.Quantity * item.f.Price : 0), // Tính tổng giá cho Đồ uống
                             SortPayment =g.Key.PaymentMonth,
                             PaymentDate = g.Key.PaymentMonth.ToString()
                         } into groupedResult // Đưa kết quả vào biến tạm
                         orderby groupedResult.SortPayment ascending // Sắp xếp theo CreatedDate tăng dần
                         select groupedResult; // Chọn kết quả đã sắp xếp

            Report = new ObservableCollection<ReportTest>(result);
        }
        private async Task DayReportClick()
        {
            // Get all  payments
            var payments = await _daoPayment.GetAllPayment();
            Payments = new  ObservableCollection<PaymentModel>(payments);
            // Get all foods
            var foods = await _daoFood.GetAllFood("");
            Foods = new ObservableCollection<FoodModel>(foods);
            // Get all payment details
            var paymentsDetail = await _daoPaymentDetail.GetAllPaymentDetail();
            PaymentsDetail = new ObservableCollection<PaymentDetailModel>(paymentsDetail);
            
            // Query
            var result = from p in Payments // Giả sử `payments` là danh sách Payments
                             join pd in PaymentsDetail on p.Id equals pd.PaymentID // Kết nối PaymentDetails
                             join f in Foods on pd.FoodId equals f.Id // Kết nối Foods
                             group new { pd, f } by new { p.Id, p.CreatedDate} into g // Nhóm theo Id, CreatedDate và Category
                             select new ReportTest
                             {
                                 Id = g.Key.Id,
                                 TotalPrice = g.Sum(item => item.pd.Quantity * item.f.Price), // Tính tổng giá
                                 TotalFoodPrice = g.Sum(item => item.f.Category == "Đồ ăn" ? item.pd.Quantity * item.f.Price : 0), // Tính tổng giá cho Đồ ăn
                                 TotalDrinkPrice = g.Sum(item => item.f.Category == "Đồ uống" ? item.pd.Quantity * item.f.Price : 0), // Tính tổng giá cho Đồ uống
                                 CreatedDate = g.Key.CreatedDate,
                                 PaymentDate = g.Key.CreatedDate.ToString(),
                             } into groupedResult // Đưa kết quả vào biến tạm
                              orderby groupedResult.CreatedDate ascending // Sắp xếp theo CreatedDate tăng dần
                              select groupedResult; // Chọn kết quả đã sắp xếp
            
            Report = new ObservableCollection<ReportTest>(result);
        }
    }
}
