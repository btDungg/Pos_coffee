using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.Views;

namespace POS_Coffee.ViewModels
{
    public class PromotionViewModel : ViewModelBase
    {
        private readonly IPromotionDao _dao;
        private readonly INavigation _navigation;

        public ICommand AddNewPromotionCommand { get; }
        //public ICommand EditPromotionCommand { get; }
        //public ICommand DeletePromotionCommand { get; }

        public PromotionViewModel(IPromotionDao dao, INavigation navigation)
        {
            _dao = dao;
            _navigation = navigation;

            AddNewPromotionCommand = new Utilities.RelayCommand(ExecuteAddNewPromotion);
            //EditPromotionCommand = new Utilities.RelayCommand<PromotionModel>(ExecuteEditPromotion);
            //DeletePromotionCommand = new Utilities.RelayCommand<PromotionModel>(ExecuteDeletePromotion);

            LoadPromotions();
        }

        private ObservableCollection<PromotionModel> _promotions;
        public ObservableCollection<PromotionModel> Promotions
        {
            get => _promotions;
            set => SetProperty(ref _promotions, value);
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (SetProperty(ref _searchQuery, value))
                {
                    FilterPromotions();
                }
            }
        }

        private bool _isActiveFilter;
        public bool IsActiveFilter
        {
            get => _isActiveFilter;
            set
            {
                if (SetProperty(ref _isActiveFilter, value))
                {
                    FilterPromotions();
                }
            }
        }

        private bool _isExpiredFilter;
        public bool IsExpiredFilter
        {
            get => _isExpiredFilter;
            set
            {
                if (SetProperty(ref _isExpiredFilter, value))
                {
                    FilterPromotions();
                }
            }
        }

        private bool _isUpcomingFilter;
        public bool IsUpcomingFilter
        {
            get => _isUpcomingFilter;
            set
            {
                if (SetProperty(ref _isUpcomingFilter, value))
                {
                    FilterPromotions();
                }
            }
        }

        // Asynchronous method to load promotions
        private async void LoadPromotions()
        {
            var promotions = await _dao.GetAllPromotionsAsync();
            Promotions = new ObservableCollection<PromotionModel>(promotions);
        }

        // Asynchronous method to filter promotions based on the filters and search query
        private async void FilterPromotions()
        {
            var promotions = await _dao.GetAllPromotionsAsync(SearchQuery, IsActiveFilter, IsExpiredFilter, IsUpcomingFilter);
            Promotions = new ObservableCollection<PromotionModel>(promotions);
        }

        private void ExecuteAddNewPromotion()
        {
            // Navigate to the AddPromotion page
            _navigation.NavigateTo(typeof(PromotionManagementPage));
        }

        //private async void ExecuteEditPromotion(PromotionModel promotion)
        //{
        //    // Navigate to the EditPromotion page
        //    if (promotion != null)
        //    {
        //        _navigation.NavigateTo(typeof(EditPromotionPage), promotion);
        //    }
        //}

        //private async void ExecuteDeletePromotion(PromotionModel promotion)
        //{
        //    if (promotion != null)
        //    {
        //        // Assuming _dao.DeletePromotionAsync exists and handles the async deletion
        //        await _dao.DeletePromotionAsync(promotion);
        //        LoadPromotions(); // Refresh list after deletion
        //    }
        //}
    }
}