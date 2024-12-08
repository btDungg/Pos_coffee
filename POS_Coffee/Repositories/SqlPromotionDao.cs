using Microsoft.EntityFrameworkCore;
using POS_Coffee.Models;
using POS_Coffee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public class SqlPromotionDao : IPromotionDao
    {
        private readonly PosDbContext _dbContext;

        public SqlPromotionDao(PosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Asynchronous version to get promotions
        public async Task<List<PromotionModel>> GetAllPromotionsAsync(string searchQuery = null, bool? isActive = null, bool? isExpired = null, bool? isUpcoming = null)
        {
            var query = _dbContext.Promotions.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(p => p.Name.Contains(searchQuery.Trim()));
            }

            if (isActive.HasValue && isActive.Value == true)
            {
                query = query.Where(p => p.start_date >= DateTime.Now && p.end_date <= DateTime.Now);
            }

            if (isExpired.HasValue && isExpired.Value == true)
            {
                query = query.Where(p => p.end_date < DateTime.Now);
            }

            if (isUpcoming.HasValue && isUpcoming.Value  == true)
            {
                query = query.Where(p => p.start_date > DateTime.Now);
            }

            return await query.ToListAsync();
        }

        // Asynchronous version to add a promotion
        public async Task AddPromotionAsync(PromotionModel promotion)
        {
            await _dbContext.Promotions.AddAsync(promotion);
            await _dbContext.SaveChangesAsync();
        }

        // Asynchronous version to get a promotion by ID
        public async Task<PromotionModel> GetPromotionByIdAsync(int id)
        {
            return await _dbContext.Promotions.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeletePromotionAsync(PromotionModel promotion)
        {
            try
            {
                var existingPromotion = await _dbContext.Promotions
                    .FirstOrDefaultAsync(p => p.Id == promotion.Id);

                if (existingPromotion != null)
                {
                    _dbContext.Promotions.Remove(existingPromotion);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("Error deleting promotion from the database.", ex);
            }
        }
    }
}
