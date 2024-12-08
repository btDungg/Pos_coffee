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
        public List<StockModel> getAllStock() 
        {
            var stockModels = new List<StockModel>()
            {
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 1,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 2,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 3,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 4,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 5,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 6,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 7,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 8,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 9,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 10,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 11,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 12,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 13,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 14,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 15,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 16,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 17,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 18,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 19,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 20,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 21,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 22,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 23,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 24,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 25,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 26,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 27,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 28,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 29,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 30,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },

            }; 
            return stockModels;
        }

        public StockModel getStockByID(int id)
        {
            var stockModels = new List<StockModel>();
            stockModels = getAllStock();
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
            stockModels = getAllStock();
            StockModel stock = stockModels.FirstOrDefault(x  => x.ID == deletedStock.ID);
            if (stock != null)
            {
                stockModels.Remove(deletedStock);
                return stock;
            }
            return null;
        }

        public List<StockModel> getSearchStock(string searchQuery)
        {
            var stockModels = new List<StockModel>()
            {
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 1,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 2,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 3,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 4,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 5,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 6,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 7,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 8,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 9,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 10,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 11,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 12,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 13,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 14,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 15,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 16,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },

                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 17,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 18,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 19,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 20,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 21,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 22,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 23,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 24,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 25,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                    ID = 26,
                    Name = "Cà phê",
                    Description = "Cà phê thương hiệu Trung Nguyên Legend",
                    Unit = "kg",
                    Price = 80000,
                    StockNumber = 0,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                    ID = 27,
                    Name = "Sữa tươi",
                    Description = "Sữa tươi Vinamilk 100% nguyên chất",
                    Unit = "hộp",
                    Price = 40000,
                    StockNumber = 10,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trungga.jpg",
                    ID = 28,
                    Name = "Trứng gà",
                    Description = "Trứng gà công nghiệp",
                    Unit = "quả",
                    Price = 3000,
                    StockNumber = 50,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/ongtho.jpg",
                    ID = 29,
                    Name = "Sữa đặc",
                    Description = "Sữa đặc Ông thọ",
                    Unit = "hộp",
                    Price = 22000,
                    StockNumber = 5,
                },
                new StockModel()
                {
                    ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                    ID = 30,
                    Name = "Trà",
                    Description = "Trà thái nguyên",
                    Unit = "kg",
                    Price = 60000,
                    StockNumber = 20,
                },

            };
            if (string.IsNullOrEmpty(searchQuery) == false)
            {
                stockModels = stockModels.Where(item => item.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return stockModels;
        }

        Task<List<StockModel>> IStockDAO.getAllStock()
        {
            throw new NotImplementedException();
        }

        Task<StockModel> IStockDAO.getStockByID(int id)
        {
            throw new NotImplementedException();
        }

        Task<StockModel> IStockDAO.RemoveStock(StockModel deletedStock)
        {
            throw new NotImplementedException();
        }

        Task<List<StockModel>> IStockDAO.getSearchStock(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public Task<StockModel> UpdateStock(StockModel stock)
        {
            throw new NotImplementedException();
        }
    }
}
