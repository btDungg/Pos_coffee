using POS_Coffee.Models;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POS_Coffee.ViewModels
{
    public class CreatePromotionViewModel : ViewModelBase
    {
        private readonly IPromotionDao _dao;
        private readonly INavigation _navigation;

        // Properties for the new promotion
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);

            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                SetProperty(ref _description, value);

            }
        }

        private string _discountType;
        public string DiscountType
        {
            get => _discountType;
            set
            {
                SetProperty(ref _discountType, value);
            }
        }

        private double _discountValue;
        public double DiscountValue
        {
            get => _discountValue;
            set
            {
                SetProperty(ref _discountValue, value);
            }
        }

        private double _minOrderValue;
        public double MinOrderValue
        {
            get => _minOrderValue;
            set
            {
                SetProperty(ref _minOrderValue, value);
            }
        }

        private DateTimeOffset? _startDate = DateTimeOffset.Now;
        public DateTimeOffset? StartDate
        {
            get => _startDate;
            set
            {
                SetProperty(ref _startDate, value);
            }
        }

        private DateTimeOffset? _endDate = DateTimeOffset.Now;
        public DateTimeOffset? EndDate
        {
            get => _endDate;
            set
            {
                SetProperty(ref _endDate, value);
            }
        }

        private string _applicableTo;
        public string ApplicableTo
        {
            get => _applicableTo;
            set
            {
                SetProperty(ref _applicableTo, value);
            }
        }

        // Các loại giảm giá
        public string[] DiscountTypes => new[] { "Phần trăm", "Số tiền cố định" };

        // Các tùy chọn áp dụng
        public string[] ApplicableToOptions => new[] { "Tất cả sản phẩm", "Đồ ăn", "Đồ uống" };

        public ICommand SavePromotionCommand { get; }
        public ICommand CancelCommand { get; }

        public CreatePromotionViewModel(IPromotionDao dao, INavigation navigation)
        {
            _dao = dao;
            _navigation = navigation;

            SavePromotionCommand = new RelayCommand(async () => await SavePromotionAsync());
            CancelCommand = new RelayCommand(Cancel);
        }



        private async Task SavePromotionAsync()
        {
            try
            {
                var newPromotion = new PromotionModel
                {
                    Name = Name,
                    Description = Description,
                    discount_type = DiscountType,
                    discount_value = (decimal)DiscountValue,
                    min_order_value = (decimal)MinOrderValue,
                    start_date = StartDate?.Date ?? DateTime.Now.Date,
                    end_date = EndDate?.Date ?? DateTime.Now.Date,
                    is_active = StartDate <= DateTime.Now && EndDate >= DateTime.Now,
                    applicable_to = ApplicableTo,
                    created_date = DateTime.Now,
                    updated_date = DateTime.Now,
                    created_by = GetCurrentUserId(),
                    updated_by = GetCurrentUserId()
                };

                // Validation logic
                if (string.IsNullOrWhiteSpace(newPromotion.Name) ||
                    string.IsNullOrWhiteSpace(newPromotion.discount_type) ||
                    newPromotion.discount_value <= 0 ||
                    newPromotion.min_order_value < 0 ||
                    newPromotion.start_date > newPromotion.end_date)
                {
                    ShowMessage("Invalid input. Please check the data and try again.");
                    _navigation.NavigateTo(typeof(CreatePromotionPage));
                    return;
                }

                await _dao.AddPromotionAsync(newPromotion);

                ShowMessage("Promotion saved successfully!");
                _navigation.NavigateTo(typeof(CreatePromotionPage));
            }
            catch (Exception ex)
            {
                LogError(ex);
                ShowMessage("An error occurred while saving the promotion. Please try again.");
                _navigation.NavigateTo(typeof(CreatePromotionPage));
            }
        }


        private void Cancel()
        {
            _navigation.NavigateTo(typeof(PromotionPage));
        }

        private int GetCurrentUserId()
        {
            return 3;
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
