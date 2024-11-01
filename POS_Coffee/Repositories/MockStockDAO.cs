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
    }
}
