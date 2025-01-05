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
    public class FoodViewModel: ViewModelBase
    {
        private XamlRoot _xamlRoot;
        private readonly IFoodDao dao;
        private INavigation _navigation;
        public List<FoodModel> _allFoods;

        // Binding variables
        private ObservableCollection<FoodModel> _foods;
        public ObservableCollection<FoodModel> Foods
        {
            get => _foods;
            set => SetProperty(ref _foods, value);
        }

        private string _searchQuery;
        public string searchQuery
        {
            get => _searchQuery;
            set => SetProperty(ref _searchQuery, value);
        }

        private FoodModel _foodDetail;
        public FoodModel FoodDetail
        {
            get => _foodDetail;
            set => SetProperty(ref _foodDetail, value);
        }

        private FoodModel _foodAddition;
        public FoodModel FoodAddition
        {
            get => _foodAddition;
            set => SetProperty(ref _foodAddition, value);
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

        public static string imagePath { get; set; }

        // Binding commands
        public ICommand AllGoodsClickCmd { get; }
        public ICommand DrinkButtonClickCmd { get; }
        public ICommand FoodButtonClickCmd { get; }
        public ICommand SearchButtonClickCmd { get; }
        public ICommand AddFoodClickCmd { get; }
        public ICommand UpdateFoodClickCmd { get; }
        public ICommand DeleteFoodClickCmd { get; }
        public ICommand SaveFoodClickCmd { get; }
        public ICommand CancelFoodClickCmd { get; }
        public ICommand UploadImageClickCmd { get; }
        public IAsyncRelayCommand LoadFoodsCommand { get; }

        public IAsyncRelayCommand LoadFoodsManagementCmd { get; }


        public FoodViewModel(IFoodDao _dao, INavigation navigation)
        {
            _navigation = navigation;
            dao = _dao;
            //LoadFoodsCommand = new AsyncRelayCommand(LoadFoods);
            LoadFoodsManagementCmd = new AsyncRelayCommand(LoadFoodsManagement);
            AllGoodsClickCmd = new RelayCommand(() => AllFoodsButtonClick());
            DrinkButtonClickCmd = new RelayCommand(() => DrinkButtonClick());
            FoodButtonClickCmd = new RelayCommand(() => FoodButtonClick());
            SearchButtonClickCmd = new RelayCommand(() => SearchButtonClick());
            AddFoodClickCmd = new RelayCommand(() => AddFoodClick());
            DeleteFoodClickCmd = new RelayCommand(DeleteFoodClick);
            UpdateFoodClickCmd = new RelayCommand(() => UpdateFoodClick());
            SaveFoodClickCmd = new RelayCommand(() => SaveFoodClick());
            CancelFoodClickCmd = new RelayCommand(() => CancelFoodClick());
            UploadImageClickCmd = new RelayCommand(() => UploadImageClick());
            LoadFoodsManagementCmd.Execute(null);
            //LoadFoodsCommand.Execute(null);
        }

        private async Task LoadFoods()
        {
            var foods = await dao.GetAllFood(null);
            Foods = new ObservableCollection<FoodModel>(foods);
        }

        private async Task LoadFoodsManagement()
        {
            var foods = await dao.GetAllFood("");
            _allFoods = new List<FoodModel>(foods);
            FoodDetail = new FoodModel();
            if (_allFoods.Any())
            {
                FoodDetail = _allFoods[0];
            }
            else
            {
                FoodDetail = null;
            }
            Foods = new ObservableCollection<FoodModel>(_allFoods);
        }

        private async void AllFoodsButtonClick()
        { 
            await LoadFoods();
        }
      
        private async void FoodButtonClick()
        {
            var filteredFoods = await dao.GetFoodsByCategory("Đồ ăn");
            Foods = new ObservableCollection<FoodModel>(filteredFoods);
        }

        private async void DrinkButtonClick()
        {
            var filteredFoods = await dao.GetFoodsByCategory("Đồ uống");
            Foods = new ObservableCollection<FoodModel>(filteredFoods);
        }

        private async void SearchButtonClick()
        {
            var foods = await dao.GetAllFood(searchQuery);
            Foods = new ObservableCollection<FoodModel>(foods);
        }

        private async void AddFoodClick()
        {
            FoodAddition = new FoodModel
            {
                Image = "",
                Name = "",
                Description = "",
                Category = "",
                Price = 0,
                Amount = 0,
            };
            // Hiển thị dialog
            var dialog = new FoodAdditionDialog
            {
                XamlRoot = _xamlRoot,
                AddedFood = FoodAddition
            };
            dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;
            await dialog.ShowAsync();
            FoodAddition = dialog.AddedFood;
        }

        private async void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            FoodAddition.Image = imagePath;
            await dao.AddFood(FoodAddition);
            var foods = await dao.GetAllFood("");
            Foods = new ObservableCollection<FoodModel>(foods);
        }

        private async void DeleteFoodClick()
        {
            var temp = dao.RemoveFood(FoodDetail);
            if (temp != null)
            {
                Foods.Remove(FoodDetail);
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

        private void UpdateFoodClick()
        {
            isReadOnly = false;
            visibilityStatus = "Collapsed";
            saveStatus = "Visible";
        }

        private async void SaveFoodClick()
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
            if(imagePath != null)
            {
                FoodDetail.Image = imagePath;
                imagePath = null;
            }
            var id = FoodDetail.Id;
            await dao.UpdateFood(FoodDetail);
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
            var foods = await dao.GetAllFood("");
            Foods = new ObservableCollection<FoodModel>(foods);
            FoodDetail = Foods.Where(x => x.Id == id).FirstOrDefault();
        }

        private void CancelFoodClick()
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

