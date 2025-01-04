using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public class MockStockDAO : IStockDAO
    {
        public List<StockModel> GetAllStock() 
        {
            throw new NotImplementedException();
        }

        public StockModel GetStockByID(int id)
        {
            var stockModels = new List<StockModel>();
            stockModels = GetAllStock();
            var stockDetail = new StockModel();
            stockDetail = stockModels.Find(x => x.ID == id);
            if (stockDetail != null)
            {
                return stockDetail;
            }
            return null;
        }

        public StockModel RemoveStock(StockModel deletedStock)
        {
            var stockModels = new List<StockModel>();
            stockModels = GetAllStock();
            StockModel stock = stockModels.FirstOrDefault(x  => x.ID == deletedStock.ID);
            if (stock != null)
            {
                stockModels.Remove(deletedStock);
                return stock;
            }
            return null;
        }

        public List<StockModel> GetSearchStock(string searchQuery)
        {

            throw new NotImplementedException();
        }

        Task<List<StockModel>> IStockDAO.GetAllStock()
        {
            throw new NotImplementedException();
        }

        Task<StockModel> IStockDAO.GetStockByID(int id)
        {
            throw new NotImplementedException();
        }

        Task<StockModel> IStockDAO.RemoveStock(StockModel deletedStock)
        {
            throw new NotImplementedException();
        }

        Task<List<StockModel>> IStockDAO.GetSearchStock(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public Task<StockModel> UpdateStock(StockModel stock)
        {
            throw new NotImplementedException();
        }
        public Task<StockModel> AddStock(StockModel stock)
        {
            throw new NotImplementedException();
        }
    }
}
