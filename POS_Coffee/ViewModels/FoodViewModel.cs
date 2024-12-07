using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RelayCommand = POS_Coffee.Utilities.RelayCommand;

namespace POS_Coffee.ViewModels
{
    public class FoodViewModel: ViewModelBase
    {

        private readonly IFoodDao dao;
        private readonly INavigation _navigation;
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
        private List<FoodModel> _allFoods;
        public ICommand AllGoodsClick { get; }
        public ICommand DrinkButtonClick { get; }
        public ICommand FoodButtonClick { get; }
        public ICommand SearchButtonClick { get; }
        public IAsyncRelayCommand LoadFoodsCommand { get; }


        public FoodViewModel(IFoodDao _dao, INavigation navigation)
        {
            _navigation = navigation;
            dao = _dao;
            LoadFoodsCommand = new AsyncRelayCommand(LoadFoods);
            AllGoodsClick = new RelayCommand(() => AllFoodsButton_Click());
            DrinkButtonClick = new RelayCommand(() => DrinkButton_Click());
            FoodButtonClick = new RelayCommand(() => FoodButton_Click());
            SearchButtonClick = new RelayCommand(() => SearchButton_Click());
            LoadFoodsCommand.Execute(null);
        }

        private async Task LoadFoods()
        {
            var foods = await dao.GetAllFood(null);
            Foods = new ObservableCollection<FoodModel>(foods);
        }

        private async void AllFoodsButton_Click()
        { 
            await LoadFoods();
        }

        private async void FoodButton_Click()
        {
            var filteredFoods = await dao.GetFoodsByCategory("Đồ ăn");
            Foods = new ObservableCollection<FoodModel>(filteredFoods);
        }

        private async void DrinkButton_Click()
        {
            var filteredFoods = await dao.GetFoodsByCategory("Đồ uống");
            Foods = new ObservableCollection<FoodModel>(filteredFoods);
        }

        private async void SearchButton_Click()
        {
            var foods = await dao.GetAllFood(searchQuery);
            Foods = new ObservableCollection<FoodModel>(foods);
        }
    }

}

