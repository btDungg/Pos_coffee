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
        public ICommand DrinkButtonClick { get; }
        public ICommand FoodButtonClick { get; }
        public ICommand SearchButtonClick { get; }

        public FoodViewModel(IFoodDao _dao, INavigation navigation)
        {
            _navigation = navigation;
            dao = _dao;
            _allFoods = dao.GetAllFood(searchQuery);
            Foods = new ObservableCollection<FoodModel>(_allFoods); // Gán danh sách ban đầu
            DrinkButtonClick = new RelayCommand(() => DrinkButton_Click());
            FoodButtonClick = new RelayCommand(() => FoodButton_Click());
            SearchButtonClick = new RelayCommand(() => SearchButton_Click());
        }

        private void FoodButton_Click()
        {
            var category = "Đồ ăn";
            var filteredFoods = _allFoods.Where(f => f.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            Foods = new ObservableCollection<FoodModel>(filteredFoods);
        }

        private void DrinkButton_Click()
        {
            var category = "Đồ uống";
            var filteredFoods = _allFoods.Where(f => f.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            Foods = new ObservableCollection<FoodModel>(filteredFoods);
        }

        private void SearchButton_Click()
        {
            Foods = new ObservableCollection<FoodModel>(dao.GetAllFood(searchQuery));
        }

    }

}

