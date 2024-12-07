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
            public string Category { get; set; }
            public decimal TotalPrice { get; set; }
            public DateTime CreatedDate { get; set; }
        }

        //Variable
        private readonly IStockDAO _daoStock;
        private readonly IPaymentDao _daoPayment;
        private readonly IPaymentDetailDao _daoPaymentDetail;
        private readonly IFoodDao _daoFood;
        private INavigation _navigation;
        private XamlRoot _xamlRoot;
        
        private ObservableCollection<ReportTest> _reportFood;
        public ObservableCollection<ReportTest> ReportFood
        {
            get => _reportFood;
            set => SetProperty(ref _reportFood, value);
        }

        private ObservableCollection<ReportTest> _reportDrink;
        public ObservableCollection<ReportTest> ReportDrink
        {
            get => _reportDrink;
            set => SetProperty(ref _reportDrink, value);
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
            MonthReportClickCmd = new AsyncRelayCommand(MonthReportClick);
            DayReportClickCmd = new AsyncRelayCommand(DayReportClick);
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

            var result = from p in Payments // Giả sử `payments` là danh sách Payments
                         join pd in PaymentsDetail on p.Id equals pd.PaymentID // Kết nối PaymentDetails
                         join f in Foods on pd.FoodId equals f.Id // Kết nối Foods
                         group new { pd, f } by new { p.Id, p.CreatedDate, f.Category } into g // Nhóm theo Id, CreatedDate và Category
                         select new ReportTest
                         {
                             Id = g.Key.Id,
                             TotalPrice = g.Sum(item => item.pd.Quantity * item.f.Price), // Tính tổng giá
                             CreatedDate = g.Key.CreatedDate,
                             Category = g.Key.Category
                         };
            ReportFood = new ObservableCollection<ReportTest>(result);
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

            var resultFood = from p in Payments // Giả sử `payments` là danh sách Payments
                         join pd in PaymentsDetail on p.Id equals pd.PaymentID // Kết nối PaymentDetails
                         join f in Foods on pd.FoodId equals f.Id // Kết nối Foods
                         where f.Category == "Đồ ăn"
                         group new { pd, f } by new { p.Id, p.CreatedDate, f.Category } into g // Nhóm theo Id, CreatedDate và Category
                         select new ReportTest
                         {
                             Id = g.Key.Id,
                             TotalPrice = g.Sum(item => item.pd.Quantity * item.f.Price), // Tính tổng giá
                             CreatedDate = g.Key.CreatedDate,
                             Category = g.Key.Category
                         } into groupedResult // Đưa kết quả vào biến tạm
                         orderby groupedResult.CreatedDate ascending // Sắp xếp theo CreatedDate tăng dần
                         select groupedResult; // Chọn kết quả đã sắp xếp
            var resultDrink = from p in Payments // Giả sử `payments` là danh sách Payments
                             join pd in PaymentsDetail on p.Id equals pd.PaymentID // Kết nối PaymentDetails
                             join f in Foods on pd.FoodId equals f.Id // Kết nối Foods
                             where f.Category == "Đồ uống"
                             group new { pd, f } by new { p.Id, p.CreatedDate, f.Category } into g // Nhóm theo Id, CreatedDate và Category
                             select new ReportTest
                             {
                                 Id = g.Key.Id,
                                 TotalPrice = g.Sum(item => item.pd.Quantity * item.f.Price), // Tính tổng giá
                                 CreatedDate = g.Key.CreatedDate,
                                 Category = g.Key.Category
                             } into groupedResult // Đưa kết quả vào biến tạm
                              orderby groupedResult.CreatedDate ascending // Sắp xếp theo CreatedDate tăng dần
                              select groupedResult; // Chọn kết quả đã sắp xếp
            var allDates = resultFood.Select(r => r.CreatedDate).Union(resultDrink.Select(r => r.CreatedDate)).Distinct().ToList();

            var reportFoodList = new ObservableCollection<ReportTest>(resultFood);
            var reportDrinkList = new ObservableCollection<ReportTest>(resultDrink);

            // Thêm vào danh sách thực phẩm nếu không có mục tương ứng trong đồ uống
            foreach (var date in allDates)
            {
                if (!reportFoodList.Any(r => r.CreatedDate == date))
                {
                    reportFoodList.Add(new ReportTest
                    {
                        CreatedDate = date,
                        TotalPrice = 0 // Hoặc giá trị mặc định khác
                    });
                }
            }

            foreach (var date in allDates)
            {
                if (!reportDrinkList.Any(r => r.CreatedDate == date))
                {
                    reportDrinkList.Add(new ReportTest
                    {
                        CreatedDate = date,
                        TotalPrice = 0 // Hoặc giá trị mặc định khác
                    });
                }
            }

            var sortedReportFood = new ObservableCollection<ReportTest>(reportFoodList.OrderBy(r => r.CreatedDate));
            var sortedReportDrink = new ObservableCollection<ReportTest>(reportDrinkList.OrderBy(r => r.CreatedDate));

            // Cập nhật lại
            ReportFood = sortedReportFood;
            ReportDrink = sortedReportDrink;
        }
    }
}
