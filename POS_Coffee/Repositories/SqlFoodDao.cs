using Microsoft.EntityFrameworkCore;
using POS_Coffee.Data;
using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public class SqlFoodDao : IFoodDao
    {
        private readonly PosDbContext _dbcontext;
        public SqlFoodDao(PosDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<List<FoodModel>> GetAllFood(string searchQuery)
        {
            var foods = _dbcontext.Foods.AsQueryable();
            if (string.IsNullOrEmpty(searchQuery) == false)
            {
                foods = foods.Where(item => item.Name.Contains(searchQuery));
            }

            return await foods.ToListAsync();

        }

        public async Task<List<FoodModel>> GetFoodsByCategory(string category)
        {
            var foods = _dbcontext.Foods.AsQueryable();
            foods = foods.Where(item => item.Category == category);
            return await foods.ToListAsync();
        }

        public async Task<int> GetQuantityById(int id)
        {
            var food = await  _dbcontext.Foods.FirstOrDefaultAsync(x => x.Id == id);  
            if (food == null)
            {
                return 0;
            }
            return food.Amount;
        }

        public async Task UpdateQuantity(List<CartItemModel> cartItems)
        {
            foreach (var item in cartItems)
            {
                var food = await _dbcontext.Foods.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (food != null)
                {
                    food.Amount -= item.Quantity;
                }
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task<FoodModel> RemoveFood(FoodModel food)
        {
            var DeletedFood = await _dbcontext.Foods.FirstOrDefaultAsync(x => x.Id == food.Id);
            if (DeletedFood == null)
            {
                return null;
            }
            _dbcontext.Remove(DeletedFood);
            await _dbcontext.SaveChangesAsync();
            return DeletedFood;
        }

        public async Task<FoodModel> UpdateFood(FoodModel food)
        {
            var UpdatedFood = await _dbcontext.Foods.FirstOrDefaultAsync(x => x.Id == food.Id);
            if (UpdatedFood == null)
            {
                return null;
            }
            UpdatedFood.Image = food.Image;
            UpdatedFood.Price = food.Price;
            UpdatedFood.Amount = food.Amount;
            UpdatedFood.Name = food.Name;
            UpdatedFood.Category = food.Category;
            UpdatedFood.Description = food.Description;
            await _dbcontext.SaveChangesAsync();
            return UpdatedFood;
        }

        public async Task<FoodModel> AddFood(FoodModel food)
        {
            await _dbcontext.AddAsync(food);
            await _dbcontext.SaveChangesAsync();
            return food;
        }
    }
}
