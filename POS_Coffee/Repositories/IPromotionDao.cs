using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Coffee.Models;

namespace POS_Coffee.Repositories
{
    public interface IPromotionDao
    {
        //List<PromotionModel> GetAllPromotions(string searchQuery = null, bool? isActive = null, bool? isExpired = null, bool? isUpcoming = null);
        //void AddPromotion(PromotionModel promotion);

            Task<List<PromotionModel>> GetAllPromotionsAsync(string searchQuery = null, bool? isActive = null, bool? isExpired = null, bool? isUpcoming = null);
            Task<PromotionModel> GetPromotionByIdAsync(int id);
            Task AddPromotionAsync(PromotionModel promotion);
        
    }
}
