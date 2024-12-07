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
    public class SqlStockDao : IStockDAO
    {
        private readonly PosDbContext _dbcontext;
        public SqlStockDao(PosDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<List<StockModel>> getAllStock()
        {
            try
            {
                var stocks = await _dbcontext.Stocks.ToListAsync();
                return stocks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

        }

        public async Task<List<StockModel>> getSearchStock(string searchQuery)
        {
            var stocks = _dbcontext.Stocks.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                stocks = stocks.Where(x => x.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
            }
            return await stocks.ToListAsync();
        }

        public async Task<StockModel> getStockByID(int id)
        {
            var stock = await _dbcontext.Stocks.FirstOrDefaultAsync(x => x.ID == id);   
            if (stock == null)
            {
                return null;
            }
            return stock;
        }

        public async Task<StockModel> RemoveStock(StockModel deletedStock)
        {
            var stock = await _dbcontext.Stocks.FirstOrDefaultAsync(x => x.ID == deletedStock.ID);
            if (stock == null)
            {
                return null;
            }
            _dbcontext.Remove(stock);
            await _dbcontext.SaveChangesAsync();
            return stock;
        }

        public Task<StockModel> UpdateStock(StockModel stock)
        {
            throw new NotImplementedException();
        }
    }
}
