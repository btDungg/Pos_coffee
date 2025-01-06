using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        public DbSet<PaymentDetailModel> PaymentDetails { get; set; }
        public DbSet<PromotionModel> Promotions { get; set; }
        public DbSet<TimeKeppingModel> TimeKeppingModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
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
                entity.Property(e => e.isActive).HasDefaultValue(true);
            });

            modelBuilder.Entity<StockModel>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<PaymentModel>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<PaymentDetailModel>(entity =>
            {
                entity.HasKey(e => new{ e.PaymentID, e.FoodId});
            });

            modelBuilder.Entity<PromotionModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.Description)
                      .HasMaxLength(500);

                entity.Property(e => e.discount_type)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.applicable_to)
                      .IsRequired()
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<TimeKeppingModel>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeID, e.WorkDate });
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
                    role = "employee",
                    name = "Nguyễn Võ Nhật Huy",
                    phone = "0123456789",
                    email = "emp1@gmail.com",
                    address = "Thủ Đức, TP Hồ Chí Minh",
                    isActive = true,
                },
                new AccountModel()
                {
                    Id = 2,
                    username = "emp2",
                    password = "emp2",
                    role = "employee",
                    name = "Bùi Tiến Dũng",
                    phone = "0805057891",
                    email = "emp2@gmail.com",
                    address = "Đông Hòa, Dĩ An, Bình Dương",
                    isActive = true,
                },
                new AccountModel()
                {
                    Id = 3,
                    username = "admin1",
                    password = "admin1",
                    role = "admin",
                    name = "Phạm Thế Duyệt",
                    phone = "0159753214",
                    email = "admin1@gmail.com",
                    address = "Thủ Đức, TP Hồ Chí Minh",
                    isActive = true,
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

            var promotions = new List<PromotionModel>
            {
                new PromotionModel
               {
                   Id = 1,
                   Name = "Giảm 10% cho hóa đơn lớn hơn 500,000",
                   Description = "Khuyến mãi áp dụng từ 01/01/2024 đến 31/01/2024",
                   discount_type = "percent",
                   discount_value = 10,
                   min_order_value = 500000,
                   start_date = new DateTime(2024, 1, 1),
                   end_date = new DateTime(2024, 1, 31),
                   is_active = true,
                   applicable_to = "all",
                   created_date = DateTime.Now,
                   updated_date = DateTime.Now,
                   created_by = 3,
                   updated_by = 3
                },
               new PromotionModel
               {
                   Id = 2,
                   Name = "Giảm 50,000 cho hóa đơn từ 300,000 trở lên",
                   Description = "Khuyến mãi cho tất cả đơn hàng từ 15/12/2023 đến 31/12/2023",
                   discount_type = "amount",
                   discount_value = 50000,
                   min_order_value = 300000,
                   start_date = new DateTime(2023, 12, 15),
                   end_date = new DateTime(2023, 12, 31),
                   is_active = true,
                   applicable_to = "all",
                   created_date = DateTime.Now,
                   updated_date = DateTime.Now,
                   created_by = 3,
                   updated_by = 3
               },
               new PromotionModel
               {
                   Id = 3,
                   Name = "Giảm giá 15% cho danh mục Đồ uống",
                   Description = "Khuyến mãi áp dụng riêng cho danh mục Đồ uống từ 01/02/2024 đến 28/02/2024",
                   discount_type = "percent",
                   discount_value = 15,
                   min_order_value = 0,
                   start_date = new DateTime(2024, 2, 1),
                   end_date = new DateTime(2024, 2, 28),
                   is_active = true,
                   applicable_to = "categories",
                   created_date = DateTime.Now,
                   updated_date = DateTime.Now,
                   created_by = 3,
                   updated_by = 3
               }                    
            };
            modelBuilder.Entity<PromotionModel>().HasData(promotions);
        }
    }
}
