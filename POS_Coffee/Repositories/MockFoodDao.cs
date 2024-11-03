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
                    Id = 1,
                    Name = "Pepsi",
                    Description = "Nước pepsi",
                    Price = 14000,
                    Amount = 12,
                    Image = "ms-appx:///Assets/pepsi.webp",
                    Category = "Đồ uống"
                },  new FoodModel
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
                    Id = 1,
                    Name = "Pepsi",
                    Description = "Nước pepsi",
                    Price = 14000,
                    Amount = 12,
                    Image = "ms-appx:///Assets/pepsi.webp",
                    Category = "Đồ uống"
                },  new FoodModel
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
                    Id = 1,
                    Name = "Pepsi",
                    Description = "Nước pepsi",
                    Price = 14000,
                    Amount = 12,
                    Image = "ms-appx:///Assets/pepsi.webp",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 1,
                    Name = "Pepsi",
                    Description = "Nước pepsi",
                    Price = 14000,
                    Amount = 12,
                    Image = "ms-appx:///Assets/pepsi.webp",
                    Category = "Đồ uống"
                },
                new FoodModel
                {
                    Id = 2,
                    Name = "Coca-Cola",
                    Description = "Nước ngọt",
                    Price = 15000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/coca_cola.jfif",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 2,
                    Name = "Coca-Cola",
                    Description = "Nước ngọt",
                    Price = 15000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/coca_cola.jfif",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 2,
                    Name = "Coca-Cola",
                    Description = "Nước ngọt",
                    Price = 15000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/coca_cola.jfif",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 2,
                    Name = "Coca-Cola",
                    Description = "Nước ngọt",
                    Price = 15000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/coca_cola.jfif",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 2,
                    Name = "Coca-Cola",
                    Description = "Nước ngọt",
                    Price = 15000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/coca_cola.jfif",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 2,
                    Name = "Coca-Cola",
                    Description = "Nước ngọt",
                    Price = 15000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/coca_cola.jfif",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 2,
                    Name = "Coca-Cola",
                    Description = "Nước ngọt",
                    Price = 15000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/coca_cola.jfif",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 2,
                    Name = "Coca-Cola",
                    Description = "Nước ngọt",
                    Price = 15000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/coca_cola.jfif",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 2,
                    Name = "Coca-Cola",
                    Description = "Nước ngọt",
                    Price = 15000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/coca_cola.jfif",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 2,
                    Name = "Coca-Cola",
                    Description = "Nước ngọt",
                    Price = 15000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/coca_cola.jfif",
                    Category = "Đồ uống"
                },
                new FoodModel
                {
                    Id = 3,
                    Name = "Mì Omachi",
                    Description = "Mì tôm",
                    Price = 20000,
                    Amount = 10,
                    Image = "ms-appx:///Assets/Omachi.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },new FoodModel
                {
                    Id = 4,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
            };

            if (string.IsNullOrEmpty(searchQuery) == false)
            {
                foods = foods.Where(item => item.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return foods;
        }
    }
}
