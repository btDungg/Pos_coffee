//using POS_Coffee.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace POS_Coffee.Repositories
//{

//    public class MockPromotionDao : IPromotionDao
//    {
//        private List<PromotionModel> promotions;

//        public MockPromotionDao()
//        {
//            promotions = new List<PromotionModel>
//            {
//                new PromotionModel
//                {
//                    Id = 1,
//                    Name = "Giảm 10% cho hóa đơn lớn hơn 500,000",
//                    Description = "Khuyến mãi áp dụng từ 01/01/2024 đến 31/01/2024",
//                    discount_type = "percent",
//                    discount_value = 10,
//                    min_order_value = 500000,
//                    start_date = new DateTime(2024, 1, 1),
//                    end_date = new DateTime(2024, 1, 31),
//                    is_active = true,
//                    applicable_to = "all",
//                    created_date = DateTime.Now,
//                    updated_date = DateTime.Now,
//                    created_by = 1,
//                    updated_by = 1
//                },
//                new PromotionModel
//                {
//                    Id = 2,
//                    Name = "Giảm 50,000 cho hóa đơn từ 300,000 trở lên",
//                    Description = "Khuyến mãi cho tất cả đơn hàng từ 15/12/2023 đến 31/12/2023",
//                    discount_type = "amount",
//                    discount_value = 50000,
//                    min_order_value = 300000,
//                    start_date = new DateTime(2023, 12, 15),
//                    end_date = new DateTime(2023, 12, 31),
//                    is_active = false, // Đã hết hạn
//                    applicable_to = "all",
//                    created_date = DateTime.Now,
//                    updated_date = DateTime.Now,
//                    created_by = 2,
//                    updated_by = 2
//                },
//                new PromotionModel
//                {
//                    Id = 3,
//                    Name = "Giảm giá 15% cho danh mục Đồ uống",
//                    Description = "Khuyến mãi áp dụng riêng cho danh mục Đồ uống từ 01/02/2024 đến 28/02/2024",
//                    discount_type = "percent",
//                    discount_value = 15,
//                    min_order_value = 0,
//                    start_date = new DateTime(2024, 2, 1),
//                    end_date = new DateTime(2024, 2, 28),
//                    is_active = false, // Sắp diễn ra
//                    applicable_to = "categories",
//                    created_date = DateTime.Now,
//                    updated_date = DateTime.Now,
//                    created_by = 1,
//                    updated_by = 3
//                },
//                new PromotionModel
//                {
//                    Id = 4,
//                    Name = "Giảm giá 15% cho danh mục Đồ uống 2025",
//                    Description = "Khuyến mãi áp dụng riêng cho danh mục Đồ uống từ 01/02/2024 đến 28/02/2025",
//                    discount_type = "percent",
//                    discount_value = 15,
//                    min_order_value = 0,
//                    start_date = new DateTime(2024, 2, 1),
//                    end_date = new DateTime(2025, 2, 28),
//                    is_active = true,
//                    applicable_to = "categories",
//                    created_date = DateTime.Now,
//                    updated_date = DateTime.Now,
//                    created_by = 1,
//                    updated_by = 3
//                },
//                new PromotionModel
//                {
//                    Id = 5,
//                    Name = "Giảm 50,000 cho hóa đơn từ 300,000 trở lên 2025",
//                    Description = "Khuyến mãi cho tất cả đơn hàng từ 15/8/2024 đến 31/12/2025",
//                    discount_type = "amount",
//                    discount_value = 50000,
//                    min_order_value = 300000,
//                    start_date = new DateTime(2024, 8, 15),
//                    end_date = new DateTime(2025, 12, 31),
//                    is_active = true,
//                    applicable_to = "all",
//                    created_date = DateTime.Now,
//                    updated_date = DateTime.Now,
//                    created_by = 2,
//                    updated_by = 2
//                }
//            };
//        }

//        public List<PromotionModel> GetAllPromotions(string searchQuery = null, bool? isActive = null, bool? isExpired = null, bool? isUpcoming = null)
//        {
//            // Tìm kiếm theo tên (nếu có query)
//            if (!string.IsNullOrEmpty(searchQuery))
//            {
//                var normalizedQuery = searchQuery.Trim().ToLowerInvariant();
//                promotions = promotions.Where(p => p.Name.ToLowerInvariant().Contains(normalizedQuery)).ToList();
//            }

//            // Lọc trạng thái khuyến mãi
//            if (isActive == true)
//            {
//                promotions = promotions.Where(p => p.is_active && p.start_date <= DateTime.Now && p.end_date >= DateTime.Now).ToList();
//            }
//            if (isExpired == true)
//            {
//                promotions = promotions.Where(p => p.end_date < DateTime.Now).ToList();
//            }
//            if (isUpcoming == true)
//            {
//                promotions = promotions.Where(p => p.start_date > DateTime.Now).ToList();
//            }

//            return promotions;
//        }

//        public void AddPromotion(PromotionModel promotion)
//        {
//            // Ensure the promotion has a unique ID
//            promotion.Id = promotions.Max(p => p.Id) + 1;
//            promotions.Add(promotion);
//        }
//    }
//}
