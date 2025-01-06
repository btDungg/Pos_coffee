using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public interface IFoodDao
    {
        Task<List<FoodModel>> GetAllFood(string searchQuery);
        Task<List<FoodModel>> GetFoodsByCategory(string category);
        Task UpdateQuantity(List<CartItemModel> cartItems);
        Task<int> GetQuantityById(int id);
        Task<FoodModel> RemoveFood(FoodModel food);
        Task<FoodModel> UpdateFood(FoodModel food);
        Task<FoodModel> AddFood(FoodModel food);
    }
}
