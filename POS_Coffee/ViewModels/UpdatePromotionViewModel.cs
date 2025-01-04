using CommunityToolkit.Mvvm.Input;
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
    public class UpdatePromotionViewModel:ViewModelBase
    {

        private readonly IPromotionDao _dao;
        private readonly INavigation _navigation;

        public UpdatePromotionViewModel(IPromotionDao dao, INavigation navigation, PromotionModel promotion)
        {
            _dao = dao;
            _navigation = navigation;

            DiscountTypes = new ObservableCollection<string> { "Phần trăm", "Số tiền cố định" };
            ApplicableToOptions = new ObservableCollection<string> { "Tất cả sản phẩm", "Đồ ăn", "Đồ uống" };

            // Khởi tạo dữ liệu từ khuyến mại được truyền vào
            Id = promotion.Id;
            Name = promotion.Name;
            Description = promotion.Description;
            DiscountType = promotion.discount_type;
            DiscountValue = (double)promotion.discount_value;
            MinOrderValue = (double)promotion.min_order_value;
            StartDate = promotion.start_date;
            EndDate = promotion.end_date;
            ApplicableTo = promotion.applicable_to;
            IsActive = promotion.is_active;

            SavePromotionCommand = new AsyncRelayCommand(SavePromotionAsync);
            CancelCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(ExecuteCancel);
        }



        public ObservableCollection<string> DiscountTypes { get; }
        public ObservableCollection<string> ApplicableToOptions { get; }

        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }


        private string _discountType;
        public string DiscountType
        {
            get => _discountType;
            set => SetProperty(ref _discountType, value);
        }

        private double _discountValue;
        public double DiscountValue
        {
            get => _discountValue;
            set => SetProperty(ref _discountValue, value);
        }

        private double _minOrderValue;
        public double MinOrderValue
        {
            get => _minOrderValue;
            set => SetProperty(ref _minOrderValue, value);
        }

        private DateTimeOffset? _startDate;
        public DateTimeOffset? StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTimeOffset? _endDate;
        public DateTimeOffset? EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }


        private string _applicableTo;
        public string ApplicableTo
        {
            get => _applicableTo;
            set => SetProperty(ref _applicableTo, value);
        }

        // Commands
        public ICommand SavePromotionCommand { get; }
        public ICommand CancelCommand { get; }

        private async Task SavePromotionAsync()
        {
            try
            {
                // Tạo đối tượng PromotionModel từ dữ liệu hiện tại
                var updatedPromotion = new PromotionModel
                {
                    Id = Id,
                    Name = Name,
                    Description = Description,
                    discount_type = DiscountType,
                    discount_value = (decimal)DiscountValue,
                    min_order_value = (decimal)MinOrderValue,
                    start_date = StartDate?.Date ?? DateTime.Now.Date,
                    end_date = EndDate?.Date ?? DateTime.Now.Date,
                    applicable_to = ApplicableTo,
                    updated_date = DateTime.Now,
                    is_active = IsActive,
                    updated_by = LoginViewModel.id
                };

                await _dao.UpdatePromotionAsync(updatedPromotion);

                ShowMessage("Promotion updated successfully!");
                _navigation.GoBack();
            }
            catch (Exception ex)
            {
                LogError(ex);
                ShowMessage("An error occurred while updating the promotion.");
            }
        }

        private void ExecuteCancel()
        {
            _navigation.GoBack();
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
