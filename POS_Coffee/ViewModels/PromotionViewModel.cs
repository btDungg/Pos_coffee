using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.Views;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace POS_Coffee.ViewModels
{
    public class PromotionViewModel : ViewModelBase
    {
        private readonly IPromotionDao _dao;
        private readonly INavigation _navigation;

        public ICommand AddNewPromotionCommand { get; }

        public ICommand UpdateSelectedPromotionCommand {  get; }
        public ICommand DeleteSelectedPromotionCommand { get; }

        public PromotionViewModel(IPromotionDao dao, INavigation navigation)
        {
            _dao = dao;
            _navigation = navigation;

            AddNewPromotionCommand = new RelayCommand(ExecuteAddNewPromotion);
            UpdateSelectedPromotionCommand = new RelayCommand<PromotionModel>(UpdatePromotionAsync);

            DeleteSelectedPromotionCommand = new RelayCommand<PromotionModel>(async (promotion) => await DeletePromotionAsync(promotion));

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

        private PromotionModel _selectedPromotion;
        public PromotionModel SelectedPromotion
        {
            get => _selectedPromotion;
            set => SetProperty(ref _selectedPromotion, value);
        }

        // Load all promotions
        private async void LoadPromotions()
        {
            var promotions = await _dao.GetAllPromotionsAsync();
            Promotions = new ObservableCollection<PromotionModel>(promotions);
        }

        // Filter promotions based on query and filters
        private async void FilterPromotions()
        {
            var promotions = await _dao.GetAllPromotionsAsync(SearchQuery, IsActiveFilter, IsExpiredFilter, IsUpcomingFilter);
            Promotions = new ObservableCollection<PromotionModel>(promotions);
        }

        private void ExecuteAddNewPromotion()
        {
            _navigation.NavigateTo(typeof(CreatePromotionPage));
        }

        private async Task DeletePromotionAsync(PromotionModel promotion)
        {
            try
            {
                if (promotion != null)
                {
                    await _dao.DeletePromotionAsync(promotion);
                    Promotions.Remove(promotion);
                    ShowMessage("Promotion deleted successfully!");
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                ShowMessage("An error occurred while deleting the promotion. Please try again.");
            }
        }

        private void UpdatePromotionAsync(PromotionModel promotion)
        {
            try
            {
                if (promotion != null)
                {
                    _navigation.NavigateTo(typeof(UpdatePromotion), promotion);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                ShowMessage("An error occurred while updating the promotion.");
            }
        }

        private void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        private void LogError(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
