using Microsoft.EntityFrameworkCore;
using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Data
{
    public class PosDbContext : DbContext
    {
        public PosDbContext(DbContextOptions<PosDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<FoodModel> Foods { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<StockModel> Stocks { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FoodModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Price)
                      .HasColumnType("decimal(18, 2)")
                      .IsRequired();
            });
            modelBuilder.Entity<AccountModel>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<StockModel>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<PaymentModel>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

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
                    Id = 2,
                    Name = "Cà phê đá",
                    Description = "Cà phê đen đá",
                    Price = 10000,
                    Amount = 10,
                    Image = "ms-appx:///Assets/coffee.jpg",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 3,
                    Name = "Bạc xỉu",
                    Description = "Bạc xỉu",
                    Price = 20000,
                    Amount = 10,
                    Image = "ms-appx:///Assets/bac-xiu.jpg",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 4,
                    Name = "Cà phê muối",
                    Description = "Cà phê muối",
                    Price = 25000,
                    Amount = 10,
                    Image = "ms-appx:///Assets/coffee-salt.jpg",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 5,
                    Name = "Trà sữa",
                    Description = "Trà sữa trân châu đường đen",
                    Price = 25000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/milktea.jpg",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 6,
                    Name = "Trà chanh",
                    Description = "Trà chanh",
                    Price = 14000,
                    Amount = 12,
                    Image = "ms-appx:///Assets/tra-chanh.jpg",
                    Category = "Đồ uống"
                },  new FoodModel
                {
                    Id = 7,
                    Name = "Revive",
                    Description = "Nước revive",
                    Price = 10000,
                    Amount = 12,
                    Image = "ms-appx:///Assets/revive.webp",
                    Category = "Đồ uống"
                },
                new FoodModel
                {
                    Id = 8,
                    Name = "Sữa chua việt quất",
                    Description = "Sữa chua việt quất",
                    Price = 25000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/suachua-vietquat.jpg",
                    Category = "Đồ uống"
                },
                new FoodModel
                {
                    Id = 9,
                    Name = "Sữa chua đá",
                    Description = "Sữa chua đá",
                    Price = 25000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/suachua-da.jpg",
                    Category = "Đồ uống"
                },
                new FoodModel
                {
                    Id = 10,
                    Name = "Sinh tố bơ",
                    Description = "Sinh tố bơ",
                    Price = 25000,
                    Amount = 15,
                    Image = "ms-appx:///Assets/sinhto-bo.jpg",
                    Category = "Đồ uống"
                },
                new FoodModel
                {
                    Id = 11,
                    Name = "Mì Omachi",
                    Description = "Mì tôm",
                    Price = 20000,
                    Amount = 10,
                    Image = "ms-appx:///Assets/Omachi.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 12,
                    Name = "Mì Hảo Hảo",
                    Description = "Mì tôm",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/HaoHao.jfif",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 13,
                    Name = "Bánh mì ngọt",
                    Description = "Bánh mì ngọt",
                    Price = 15000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/banhmingot.jpg",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 14,
                    Name = "Snack",
                    Description = "Snack",
                    Price = 10000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/snack.jpg",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 15,
                    Name = "Đậu phộng",
                    Description = "Đậu phộng",
                    Price = 10000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/dauphong.jpg",
                    Category = "Đồ ăn"
                },
                new FoodModel
                {
                    Id = 16,
                    Name = "Hạt hướng dương",
                    Description = "Hạt hướng dương",
                    Price = 10000,
                    Amount = 20,
                    Image = "ms-appx:///Assets/huongduong.jpg",
                    Category = "Đồ ăn"
                }
            };

            modelBuilder.Entity<FoodModel>().HasData(foods);

            var accountModels = new List<AccountModel>()
            {
                new AccountModel()
                {
                    Id = 1,
                    username = "emp1",
                    password = "emp1",
                    role = "employee"
                },
                new AccountModel()
                {
                    Id = 2,
                    username = "emp2",
                    password = "emp2",
                    role = "employee"
                },
                new AccountModel()
                {
                    Id = 3,
                    username = "admin1",
                    password = "admin1",
                    role = "admin"
                }
            };

            modelBuilder.Entity<AccountModel>().HasData(accountModels);

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
            };

            modelBuilder.Entity<StockModel>().HasData(stockModels);

        }
    }
}
