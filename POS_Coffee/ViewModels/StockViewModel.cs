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
        public ICommand SaveStockAdditionClickCmd { get; }
        public ICommand CancelStockAdditionClickCmd { get; }
        public ICommand UploadImageClickCmd { get; }

        public IAsyncRelayCommand LoadStocksCommand;

        //Variable
        private XamlRoot _xamlRoot;

        private StockModel OldStockDetail;

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

        private string _nameErrorStatus = "Collapsed";
        public string NameErrorStatus
        {
            get => _nameErrorStatus;
            set => SetProperty(ref _nameErrorStatus, value);
        }

        private string _priceErrorStatus = "Collapsed";
        public string PriceErrorStatus
        {
            get => _priceErrorStatus;
            set => SetProperty(ref _priceErrorStatus, value);
        }

        private string _amountErrorStatus = "Collapsed";
        public string AmountErrorStatus
        {
            get => _amountErrorStatus;
            set => SetProperty(ref _amountErrorStatus, value);
        }

        private string _unitErrorStatus = "Collapsed";
        public string UnitErrorStatus
        {
            get => _unitErrorStatus;
            set => SetProperty(ref _unitErrorStatus, value);
        }

        private string _imageErrorStatus = "Collapsed";
        public string ImageErrorStatus
        {
            get => _imageErrorStatus;
            set => SetProperty(ref _imageErrorStatus, value);
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
            SaveStockAdditionClickCmd = new RelayCommand(() => SaveStockAdditionClick());
            CancelStockAdditionClickCmd = new RelayCommand(() => CancelStockAdditionClick());
            UploadImageClickCmd = new RelayCommand(() => UploadImageClick());
            LoadStocksCommand = new AsyncRelayCommand(LoadStocks);
            LoadStocksCommand.Execute(null);
        }

        private async Task LoadStocks()
        {
            var stocks = await _stockDao.GetAllStock();
            allStocks = new List<StockModel>(stocks);
            StockDetail = new StockModel();
            if (allStocks.Any())
            {
                StockDetail = allStocks[0];
                OldStockDetail = new StockModel();
                OldStockDetail = StockDetail;
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

        private void AddStockClick()
        {
            _navigation.NavigateTo(typeof(StockAdditionPage));
        }

        private async void SaveStockAdditionClick()
        {
            var name = true;
            var price = true;
            var amount = true;
            var category = true;
            var image = true;
            if (StockAddition.Name == "" || StockAddition.Name == null)
            {
                NameErrorStatus = "Visible";
                name = false;
            }
            if (StockAddition.Unit == "" || StockAddition.Unit == null)
            {
                UnitErrorStatus = "Visible";
                category = false;
            }
            if (StockAddition.Price.ToString() == null || StockAddition.Price.ToString() == "" || StockAddition.Price < 0)
            {
                PriceErrorStatus = "Visible";
                price = false;
            }
            if (StockAddition.StockNumber.ToString() == null || StockAddition.StockNumber.ToString() == "" || StockAddition.StockNumber < 0 || !(StockAddition.StockNumber is int))
            {
                AmountErrorStatus = "Visible";
                amount = false;
            }
            if (imagePath != null)
            {
                StockAddition.ImagePath = imagePath;
                imagePath = null;
            }
            else
            {
                ImageErrorStatus = "Visible";
                image = false;
            }
            var id = StockAddition.ID;
            if (name == true && price == true && amount == true && category == true && image == true)
            {
                await _stockDao.AddStock(StockAddition);
                var dialog = new ContentDialog()
                {
                    XamlRoot = _xamlRoot,
                    Content = "Thêm thành công",
                    Title = "Thêm món mới",
                    CloseButtonText = "Ok",
                };
                NameErrorStatus = "Collapsed";
                UnitErrorStatus = "Collapsed";
                PriceErrorStatus = "Collapsed";
                AmountErrorStatus = "Collapsed";
                isReadOnly = true;
                visibilityStatus = "Visible";
                saveStatus = "Collapsed";
                _navigation.NavigateTo(typeof(StockManagementPage));
            }

        }

        private void CancelStockAdditionClick()
        {
            NameErrorStatus = "Collapsed";
            UnitErrorStatus = "Collapsed";
            PriceErrorStatus = "Collapsed";
            AmountErrorStatus = "Collapsed";
            isReadOnly = true;
            visibilityStatus = "Visible";
            saveStatus = "Collapsed";
            _navigation.NavigateTo(typeof(StockManagementPage));
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
            var name = true;
            var price = true;
            var amount = true;
            var unit = true;
            if (StockDetail.Name == "")
            {
                NameErrorStatus = "Visible";
                name = false;
            }
            if (StockDetail.Unit == "")
            {
                UnitErrorStatus = "Visible";
                unit = false;
            }
            if (StockDetail.Price.ToString() == null || StockDetail.Price.ToString() == "" || StockDetail.Price < 0)
            {
                PriceErrorStatus = "Visible";
                price = false;
            }
            if (StockDetail.StockNumber.ToString() == null || StockDetail.StockNumber.ToString() == "" || StockDetail.StockNumber < 0 || !(StockDetail.StockNumber is int))
            {
                AmountErrorStatus = "Visible";
                amount = false;
            }
            if (imagePath != null)
            {
                StockDetail.ImagePath = imagePath;
                imagePath = null;
            }
            var id = StockDetail.ID;
            if (name == true && price == true && amount == true && unit == true)
            {
                StockDetail = await _stockDao.UpdateStock(StockDetail);
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
                NameErrorStatus = "Collapsed";
                PriceErrorStatus = "Collapsed";
                AmountErrorStatus = "Collapsed";
                UnitErrorStatus = "Collapsed";
                isReadOnly = true;
                visibilityStatus = "Visible";
                saveStatus = "Collapsed";
                var stocks = await _stockDao.GetAllStock();
                Stocks = new ObservableCollection<StockModel>(stocks);
                StockDetail = Stocks.Where(x => x.ID == id).FirstOrDefault();
            }
        }

        private async void CancelStockClick()
        {
            string name = OldStockDetail.Name;
            isReadOnly = true;
            visibilityStatus = "Visible";
            saveStatus = "Collapsed";
            NameErrorStatus = "Collapsed";
            PriceErrorStatus = "Collapsed";
            AmountErrorStatus = "Collapsed";
            UnitErrorStatus = "Collapsed";
            StockDetail = OldStockDetail;
            var stocks = await _stockDao.GetAllStock();
            Stocks = new ObservableCollection<StockModel>(stocks);
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
