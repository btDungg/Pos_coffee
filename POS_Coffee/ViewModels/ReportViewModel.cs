using Microsoft.UI.Xaml;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public List<StockModel> allStocks { get; set; }

        private readonly IStockDAO _dao;

        private INavigation _navigation;
        private XamlRoot _xamlRoot;
        //Variable
        private ObservableCollection<StockModel> _stocks;
        public ObservableCollection<StockModel> Stocks
        {
            get => _stocks;
            set => SetProperty(ref _stocks, value);
        }

        private ObservableCollection<GroupedStock> _reportStocks;
        public ObservableCollection<GroupedStock> ReportStocks
        {
            get => _reportStocks;
            set => SetProperty(ref _reportStocks, value);
        }

        public ICommand AllStockClickCmd { get; }

        public ReportViewModel(IStockDAO stockDAO)
        {
            _dao = stockDAO;
        }

        public ReportViewModel(IStockDAO stockDAO, INavigation navigation)
        {
            _dao = stockDAO;
            allStocks = new List<StockModel>(_dao.getAllStock());
            Stocks = new ObservableCollection<StockModel>(allStocks);
            _navigation = navigation;
            AllStockClickCmd = new RelayCommand(() => AllStockClick());
        }

        private void AllStockClick()
        {
            var filteredStocks = allStocks
                .GroupBy(stock => stock.Name) // Nhóm theo Name
                .Select(g => new GroupedStock
                {
                    Name = g.Key,
                    TotalStockNumber = g.Sum(stock => stock.StockNumber), 
                    ReportStocks = g.ToList()
                })
                .ToList();
            ReportStocks = new ObservableCollection<GroupedStock>(filteredStocks);
        }
        //public void SetXamlRoot(XamlRoot xamlRoot)
        //{
        //    _xamlRoot = xamlRoot;
        //}
    }
}
