using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
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

        private readonly IStockDAO _dao;

        private INavigation _navigation;

        //Command:
        public ICommand RowSelectedCommand { get; }  
        public ICommand AllStockClickCmd { get; }
        public ICommand NormalStockClickCmd { get; }
        public ICommand LowStockClickCmd { get; }
        public ICommand UseUpStockClickCmd { get; }
        public ICommand AddStockClickCmd { get; }
        public ICommand UpdateStockClickCmd { get; }
        public ICommand DeleteStockClickCmd { get; }
        public ICommand SearchButtonClickCmd { get; }

        //Variable
        private ObservableCollection<StockModel> _stocks;
        private XamlRoot _xamlRoot;

        public ObservableCollection<StockModel> Stocks
        {
            get => _stocks;
            set => SetProperty(ref _stocks, value);
        }

        private string _searchQuery;
        public string searchQuery
        {
            get => _searchQuery;
            set => SetProperty(ref _searchQuery, value);
        }

        public StockViewModel(IStockDAO stockDAO)
        {
            _dao = stockDAO;
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
            RowSelectedCommand = new CommunityToolkit.Mvvm.Input.RelayCommand<StockModel>(LoadDetail);
            AllStockClickCmd = new RelayCommand(() => AllStockClick());
            NormalStockClickCmd = new RelayCommand(() => NormalStockClick());
            LowStockClickCmd = new RelayCommand(() => LowStockClick());
            UseUpStockClickCmd = new RelayCommand(() => UseUpStockClick());
            AddStockClickCmd = new RelayCommand(() => AddStockClick());
            DeleteStockClickCmd = new RelayCommand(DeleteStockClick);
            UpdateStockClickCmd = new CommunityToolkit.Mvvm.Input.RelayCommand<StockModel>(UpdateStockClick);
            SearchButtonClickCmd = new RelayCommand(() => SearchStockClick());
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

        private void SearchStockClick()
        {
            Stocks = new ObservableCollection<StockModel>(_dao.getSearchStock(searchQuery));
        }

        private void AddStockClick()
        {

        }

        private async void DeleteStockClick()
        {
            var temp = _dao.RemoveStock(StockDetail);
            if (temp != null)
            {
                Stocks.Remove(StockDetail);
                var dialog = new ContentDialog()
                {
                    XamlRoot = _xamlRoot,
                    Content = "Xóa thành công",
                    Title = "Thành công",
                    CloseButtonText = "Ok",
                };
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new ContentDialog()
                {
                    XamlRoot = _xamlRoot,
                    Content = "Xóa thất bại",
                    Title = "Thất bại",
                    CloseButtonText = "Ok",
                };
                await dialog.ShowAsync();
            }
        }

        private void UpdateStockClick(StockModel updatedStock)
        {

        }

        public void SetXamlRoot(XamlRoot xamlRoot)
        {
            _xamlRoot = xamlRoot;
        }

    }
}
