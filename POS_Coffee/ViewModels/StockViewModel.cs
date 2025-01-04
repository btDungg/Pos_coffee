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
using Windows.ApplicationModel.Payments;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;
using Windows.Storage;
using Windows.Storage.Pickers;
using WinRT.Interop;

namespace POS_Coffee.ViewModels
{
    public class StockViewModel : ViewModelBase
    {
        public List<StockModel> allStocks { get; set; }

        private readonly IStockDAO _stockDao;

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
        public ICommand UploadImageClickCmd { get; }

        public IAsyncRelayCommand LoadStocksCommand;

        //Variable
        private XamlRoot _xamlRoot;

        private StockModel _stockDetail;
        public StockModel StockDetail
        {
            get => _stockDetail;
            set => SetProperty(ref _stockDetail, value);
        }

        private StockModel _stockAddition;
        public StockModel StockAddition
        {
            get => _stockAddition;
            set => SetProperty(ref _stockAddition, value);
        }


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

        private ObservableCollection<StockModel> _stocks;
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

        public static string imagePath { get; set; }

        public StockViewModel(IStockDAO stockDAO)
        {
            _stockDao = stockDAO;
        }

        public StockViewModel(IStockDAO stockDAO, INavigation navigation) 
        {
            _stockDao = stockDAO;
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
            UploadImageClickCmd = new RelayCommand(() => UploadImageClick());
            LoadStocksCommand = new AsyncRelayCommand(LoadStocks);
            LoadStocksCommand.Execute(null);
        }

        private async Task LoadStocks()
        {
            var stocks = await _stockDao.GetAllStock();
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
            var stocks = await _stockDao.GetSearchStock(searchQuery);
            Stocks = new ObservableCollection<StockModel>(stocks);
        }

        private async void AddStockClick()
        {
            StockAddition = new StockModel
            {
                ImagePath = "",
                Name = "",
                Description = "",
                Unit = "",
                Price = 0,
                StockNumber = 0,
            };
            // Hiển thị dialog
            var dialog = new StockAdditionDialog
            {
                XamlRoot = _xamlRoot,
                AddedStock = StockAddition
            };
            dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;
            await dialog.ShowAsync();
            StockAddition = dialog.AddedStock;
        }

        private async void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            StockAddition.ImagePath = imagePath;
            await _stockDao.AddStock(StockAddition);
            var stocks = await _stockDao.GetAllStock();
            Stocks = new ObservableCollection<StockModel>(stocks);
        }

        private async void DeleteStockClick()
        {
            var temp = _stockDao.RemoveStock(StockDetail);
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
            //if(stockDetailChanged.Name != null)
            //{
            //    StockDetail.Name = stockDetailChanged.Name;
            //    stockDetailChanged.Name = null;
            //}
            //if (stockDetailChanged.Description != null)
            //{
            //    StockDetail.Description = stockDetailChanged.Description;
            //    stockDetailChanged.Description = null;
            //}
            //if (stockDetailChanged.Unit != null)
            //{
            //    StockDetail.Unit = stockDetailChanged.Unit;
            //    stockDetailChanged.Unit = null;
            //}
            //if (stockDetailChanged.Price >= 0)
            //{
            //    StockDetail.Price = stockDetailChanged.Price;
            //    stockDetailChanged.Price = -1;
            //}
            //if (stockDetailChanged.StockNumber >= 0)
            //{
            //    StockDetail.StockNumber = stockDetailChanged.StockNumber;
            //    stockDetailChanged.StockNumber = -1;
            //}
            StockDetail.ImagePath = imagePath;
            await _stockDao.UpdateStock(StockDetail);
            var stocks = await _stockDao.GetAllStock();
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
        private async void UploadImageClick()
        {
            FileOpenPicker fileOpenPicker = new()
            {
                ViewMode = PickerViewMode.Thumbnail,
                FileTypeFilter = { ".jpg", ".jpeg", ".png", ".gif" },
            };

            var windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(App.Window);
            WinRT.Interop.InitializeWithWindow.Initialize(fileOpenPicker, windowHandle);

            StorageFile file = await fileOpenPicker.PickSingleFileAsync();

            if (file != null)
            {
                imagePath = file.Path;
                //ImagePreview.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(file.Path));
            }
        }
        

        public void SetXamlRoot(XamlRoot xamlRoot)
        {
            _xamlRoot = xamlRoot;
        }

    }
}
