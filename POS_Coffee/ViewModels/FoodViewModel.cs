﻿using Microsoft.UI.Xaml;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
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
        private ObservableCollection<FoodModel> _foods;
        public ObservableCollection<FoodModel> Foods
        {
            get => _foods;
            set => SetProperty(ref _foods, value);
        }

        private ObservableCollection<FoodModel> _allFoods;

        public ICommand DrinkButtonClick { get; }
        public ICommand FoodButtonClick { get; }

        public FoodViewModel(IFoodDao _dao)
        {
            dao = _dao;
            _allFoods = new ObservableCollection<FoodModel>(dao.GetAllFood()); // Lưu tất cả món ăn
            Foods = new ObservableCollection<FoodModel>(_allFoods); // Gán danh sách ban đầu
            DrinkButtonClick = new Utilities.RelayCommand(() => DrinkButton_Click());
            FoodButtonClick = new Utilities.RelayCommand(() => FoodButton_Click());
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
    


}

}

