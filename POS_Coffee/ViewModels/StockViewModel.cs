using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.Views;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace POS_Coffee.ViewModels
{
    public class StockViewModel : ViewModelBase
    {
        public List<StockModel> allStocks { get; set; }

        private StockModel _stockDetail;
        public StockModel StockDetail
        {
            get => _stockDetail;
            set => SetProperty(ref _stockDetail, value);
        }

        private readonly IStockDAO _dao;

        private INavigation _navigation;

        //Command:
        public ICommand AllStockClickCmd { get; }
        public ICommand NormalStockClickCmd { get; }
        public ICommand LowStockClickCmd { get; }
        public ICommand UseUpStockClickCmd { get; }
        public ICommand AddStockClickCmd { get; }
        public ICommand UpdateStockClickCmd { get; }
        public ICommand DeleteStockClickCmd { get; }
        public ICommand SearchButtonClickCmd { get; }
        public ICommand SaveStockClickCmd { get; }
        public ICommand CancelStockClickCmd { get; }
        public ICommand ChangeDetailCmd { get; }
        public IAsyncRelayCommand LoadStocksCommand;

        //Variable
        private ObservableCollection<StockModel> _stocks;
        private XamlRoot _xamlRoot;

        private bool _isReadOnly = true;
        public bool isReadOnly
        {
            get => _isReadOnly;
            set => SetProperty(ref _isReadOnly, value);
        }

        private string _visibilityStatus = "Visible";
        public string visibilityStatus
        {
            get => _visibilityStatus;
            set => SetProperty(ref _visibilityStatus, value);
        }

        private string _saveStatus = "Collapsed";
        public string saveStatus
        {
            get => _saveStatus;
            set => SetProperty(ref _saveStatus, value);
        }

        

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
            _navigation = navigation;
              
            AllStockClickCmd = new RelayCommand(() => AllStockClick());
            NormalStockClickCmd = new RelayCommand(() => NormalStockClick());
            LowStockClickCmd = new RelayCommand(() => LowStockClick());
            UseUpStockClickCmd = new RelayCommand(() => UseUpStockClick());
            AddStockClickCmd = new RelayCommand(() => AddStockClick());
            DeleteStockClickCmd = new RelayCommand(DeleteStockClick);
            UpdateStockClickCmd = new RelayCommand(() => UpdateStockClick());
            SearchButtonClickCmd = new RelayCommand(() => SearchStockClick());
            SaveStockClickCmd = new RelayCommand(()=>SaveStockClick());
            CancelStockClickCmd = new RelayCommand(() => CancelStockClick());
            LoadStocksCommand = new AsyncRelayCommand(LoadStocks);
            LoadStocksCommand.Execute(null);
        }

        private async Task LoadStocks()
        {
            var stocks = await _dao.getAllStock();
            allStocks = new List<StockModel>(stocks);
            if (allStocks.Any())
            {
                StockDetail = allStocks[0];
            }
            else
            {
                StockDetail = null;
            }
            Stocks = new ObservableCollection<StockModel>(allStocks);
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

        private async void SearchStockClick()
        {
            var stocks = await _dao.getSearchStock(searchQuery);
            Stocks = new ObservableCollection<StockModel>(stocks);
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

        private void UpdateStockClick()
        {
            isReadOnly = false;
            visibilityStatus = "Collapsed";
            saveStatus = "Visible";
        }

        private async void SaveStockClick()
        {
            await _dao.UpdateStock(StockDetail);
            var stocks = await _dao.getAllStock();
            Stocks = new ObservableCollection<StockModel>(stocks);
            isReadOnly = true;
            visibilityStatus = "Visible";
            saveStatus = "Collapsed";
            var dialog = new ContentDialog()
            {
                XamlRoot = _xamlRoot,
                Content = "Lưu thành công",
                Title = "Lưu thay đổi",
                CloseButtonText = "Ok",
            };
            await dialog.ShowAsync();
        }

        private void CancelStockClick()
        {
            isReadOnly = true;
            visibilityStatus = "Visible";
            saveStatus = "Collapsed";
        }

        public void SetXamlRoot(XamlRoot xamlRoot)
        {
            _xamlRoot = xamlRoot;
        }

    }
}
