using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public interface IStockDAO
    {
        Task<List<StockModel>> getAllStock();
        Task<StockModel> getStockByID(int id);
        Task<StockModel> RemoveStock(StockModel deletedStock);
        Task<List<StockModel>> getSearchStock(string searchQuery);
        Task<StockModel> UpdateStock(StockModel stock);
    }
}
