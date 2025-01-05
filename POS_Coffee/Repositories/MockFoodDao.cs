using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Coffee.Models;

namespace POS_Coffee.Repositories
{
    public class MockFoodDao : IFoodDao
    {
        public List<FoodModel> GetAllFood(string searchQuery)
        {
            var foods = new List<FoodModel>
            {
                new FoodModel
                {
                    Id = 1,
                    Name = "Pepsi",
                    Description = "Nước pepsi",
                    Price = 14000,
                    Amount = 12,
                    Image = "ms-appx:///Assets/pepsi.webp",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 2,
                    Name = "Cà phê đá",
                    Description = "Cà phê đen đá",
                    Price = 10000,
                    Amount = 10,
                    Image = "ms-appx:///Assets/coffee.jpg",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 3,
                    Name = "Bạc xỉu",
                    Description = "Bạc xỉu",
                    Price = 20000,
                    Amount = 10,
                    Image = "ms-appx:///Assets/bac-xiu.jpg",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 4,
                    Name = "Cà phê muối",
                    Description = "Cà phê muối",
                    Price = 25000,
                    Amount = 10,
                    Image = "ms-appx:///Assets/coffee-salt.jpg",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 5,
                    Name = "Trà sữa",
                    Description = "Trà sữa trân châu đường đen",
                    Price = 25000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/milktea.jpg",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 6,
                    Name = "Trà chanh",
                    Description = "Trà chanh",
                    Price = 14000,
                    Amount = 12,
                    Image = "ms-appx:///Assets/tra-chanh.jpg",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 7,
                    Name = "Revive",
                    Description = "Nước revive",
                    Price = 10000,
                    Amount = 12,
                    Image = "ms-appx:///Assets/revive.webp",
                    Category = "Đồ uống"
                },
                new FoodModel
                {
                    Id = 8,
                    Name = "Sữa chua việt quất",
                    Description = "Sữa chua việt quất",
                    Price = 25000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/suachua-vietquat.jpg",
                    Category = "Đồ uống"
                },
                new FoodModel
                {
                    Id = 9,
                    Name = "Sữa chua đá",
                    Description = "Sữa chua đá",
                    Price = 25000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/suachua-da.jpg",
                    Category = "Đồ uống"
                },
                new FoodModel
                {
                    Id = 10,
                    Name = "Sinh tố bơ",
                    Description = "Sinh tố bơ",
                    Price = 25000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/sinhto-bo.jpg",
                    Category = "Đồ uống"
                },
                new FoodModel
                {
                    Id = 11,
                    Name = "Mì Omachi",
                    Description = "Mì tôm",
                    Price = 20000,
                    Amount = 10,
                    Image = "ms-appx:///Assets/Omachi.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 12,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 13,
                    Name = "Bánh mì ngọt",
                    Description = "Bánh mì ngọt",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/banhmingot.jpg",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 14,
                    Name = "Snack",
                    Description = "Snack",
                    Price = 10000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/snack.jpg",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 15,
                    Name = "Đậu phộng",
                    Description = "Đậu phộng",
                    Price = 10000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/dauphong.jpg",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 16,
                    Name = "Hạt hướng dương",
                    Description = "Hạt hướng dương",
                    Price = 10000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/huongduong.jpg",
                    Category = "Đồ ăn"
                },

            };

            if (string.IsNullOrEmpty(searchQuery) == false)
            {
                foods = foods.Where(item => item.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return foods;
        }

        public Task<List<FoodModel>> GetFoodsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuantity(List<CartItemModel> cartItems)
        {
            throw new NotImplementedException();
        }

        Task<List<FoodModel>> IFoodDao.GetAllFood(string searchQuery)
        {
            throw new NotImplementedException();
        }

        Task<FoodModel> IFoodDao.RemoveFood(FoodModel deletedStock)
        {
            throw new NotImplementedException();
        }

        public Task<FoodModel> UpdateFood(FoodModel stock)
        {
            throw new NotImplementedException();
        }
        public Task<FoodModel> AddFood(FoodModel stock)
        {
            throw new NotImplementedException();
        }
    }
}
