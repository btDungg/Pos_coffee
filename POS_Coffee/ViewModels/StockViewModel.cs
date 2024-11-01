using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.Views;

namespace POS_Coffee.ViewModels
{
    public class StockViewModel : ViewModelBase
    {
        public List<StockModel> allStocks { get; set; }

        public StockModel StockDetail { get; set; }

        private IStockDAO _dao = null;

        private INavigation _navigation;

        //Command:
        public ICommand RowSelectedCommand { get; }  
        public ICommand AllStockClickCmd { get; }
        public ICommand NormalStockClickCmd { get; }
        public ICommand LowStockClickCmd { get; }
        public ICommand UseUpStockClickCmd { get; }
        public ICommand SearchButtonClickCmd { get; }

        //Variable
        private ObservableCollection<StockModel> _stocks;
        public ObservableCollection<StockModel> Stocks
        {
            get => _stocks;
            set => SetProperty(ref _stocks, value);
        }

        public StockViewModel(IStockDAO stockDAO, INavigation navigation) 
        { 
            _dao = stockDAO;
            allStocks = new List<StockModel>(_dao.getAllStock());
            Stocks = new ObservableCollection<StockModel>(allStocks);
            _navigation = navigation;
            StockDetail = new StockModel();
            if (allStocks.Any())
            {
                StockDetail = allStocks[0];
            }
            else
            {
                StockDetail = null;
            }    
            //RowSelectedCommand = new RelayCommand(() => LoadDetail());
            RowSelectedCommand = new CommunityToolkit.Mvvm.Input.RelayCommand<StockModel>(LoadDetail);
            AllStockClickCmd = new RelayCommand(() => AllStockClick());
            NormalStockClickCmd = new RelayCommand(() => NormalStockClick());
            LowStockClickCmd = new RelayCommand(() => LowStockClick());
            UseUpStockClickCmd = new RelayCommand(() => UseUpStockClick());
            //SearchButtonClickCmd = new RelayCommand(() => SearchStockClick());
        }

        private void LoadDetail(StockModel stock)
        {
            StockDetail = new StockModel();
            StockDetail = stock;
        }

        private void AllStockClick() 
        { 
            Stocks = new ObservableCollection<StockModel>(allStocks); 
        }

        private void NormalStockClick()
        {
            var ammount = 20;
            var filteredStocks = allStocks.Where(f => (f.StockNumber >= ammount)).ToList();
            Stocks = new ObservableCollection<StockModel>(filteredStocks);
        }

        private void LowStockClick()
        {
            var ammount = 20;
            var filteredStocks = allStocks.Where(f => (f.StockNumber < ammount)).ToList();
            Stocks = new ObservableCollection<StockModel>(filteredStocks);
        }

        private void UseUpStockClick()
        {
            var ammount = 0;
            var filteredStocks = allStocks.Where(f => (f.StockNumber == ammount)).ToList();
            Stocks = new ObservableCollection<StockModel>(filteredStocks);
        }

        //private void SearchStockClick()
        //{
            
        //}

    }
}
