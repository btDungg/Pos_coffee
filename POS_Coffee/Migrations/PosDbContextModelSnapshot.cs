﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS_Coffee.Data;

#nullable disable

namespace POS_Coffee.Migrations
{
    [DbContext(typeof(PosDbContext))]
    partial class PosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("POS_Coffee.Models.AccountModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            password = "emp1",
                            role = "employee",
                            username = "emp1"
                        },
                        new
                        {
                            Id = 2,
                            password = "emp2",
                            role = "employee",
                            username = "emp2"
                        },
                        new
                        {
                            Id = 3,
                            password = "admin1",
                            role = "admin",
                            username = "admin1"
                        });
                });

            modelBuilder.Entity("POS_Coffee.Models.FoodModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 12,
                            Category = "Đồ uống",
                            Description = "Nước pepsi",
                            Image = "ms-appx:///Assets/pepsi.webp",
                            Name = "Pepsi",
                            Price = 14000m
                        },
                        new
                        {
                            Id = 2,
                            Amount = 10,
                            Category = "Đồ uống",
                            Description = "Cà phê đen đá",
                            Image = "ms-appx:///Assets/coffee.jpg",
                            Name = "Cà phê đá",
                            Price = 10000m
                        },
                        new
                        {
                            Id = 3,
                            Amount = 10,
                            Category = "Đồ uống",
                            Description = "Bạc xỉu",
                            Image = "ms-appx:///Assets/bac-xiu.jpg",
                            Name = "Bạc xỉu",
                            Price = 20000m
                        },
                        new
                        {
                            Id = 4,
                            Amount = 10,
                            Category = "Đồ uống",
                            Description = "Cà phê muối",
                            Image = "ms-appx:///Assets/coffee-salt.jpg",
                            Name = "Cà phê muối",
                            Price = 25000m
                        },
                        new
                        {
                            Id = 5,
                            Amount = 15,
                            Category = "Đồ uống",
                            Description = "Trà sữa trân châu đường đen",
                            Image = "ms-appx:///Assets/milktea.jpg",
                            Name = "Trà sữa",
                            Price = 25000m
                        },
                        new
                        {
                            Id = 6,
                            Amount = 12,
                            Category = "Đồ uống",
                            Description = "Trà chanh",
                            Image = "ms-appx:///Assets/tra-chanh.jpg",
                            Name = "Trà chanh",
                            Price = 14000m
                        },
                        new
                        {
                            Id = 7,
                            Amount = 12,
                            Category = "Đồ uống",
                            Description = "Nước revive",
                            Image = "ms-appx:///Assets/revive.webp",
                            Name = "Revive",
                            Price = 10000m
                        },
                        new
                        {
                            Id = 8,
                            Amount = 15,
                            Category = "Đồ uống",
                            Description = "Sữa chua việt quất",
                            Image = "ms-appx:///Assets/suachua-vietquat.jpg",
                            Name = "Sữa chua việt quất",
                            Price = 25000m
                        },
                        new
                        {
                            Id = 9,
                            Amount = 15,
                            Category = "Đồ uống",
                            Description = "Sữa chua đá",
                            Image = "ms-appx:///Assets/suachua-da.jpg",
                            Name = "Sữa chua đá",
                            Price = 25000m
                        },
                        new
                        {
                            Id = 10,
                            Amount = 15,
                            Category = "Đồ uống",
                            Description = "Sinh tố bơ",
                            Image = "ms-appx:///Assets/sinhto-bo.jpg",
                            Name = "Sinh tố bơ",
                            Price = 25000m
                        },
                        new
                        {
                            Id = 11,
                            Amount = 10,
                            Category = "Đồ ăn",
                            Description = "Mì tôm",
                            Image = "ms-appx:///Assets/Omachi.jfif",
                            Name = "Mì Omachi",
                            Price = 20000m
                        },
                        new
                        {
                            Id = 12,
                            Amount = 20,
                            Category = "Đồ ăn",
                            Description = "Mì tôm",
                            Image = "ms-appx:///Assets/HaoHao.jfif",
                            Name = "Mì Hảo Hảo",
                            Price = 15000m
                        },
                        new
                        {
                            Id = 13,
                            Amount = 20,
                            Category = "Đồ ăn",
                            Description = "Bánh mì ngọt",
                            Image = "ms-appx:///Assets/banhmingot.jpg",
                            Name = "Bánh mì ngọt",
                            Price = 15000m
                        },
                        new
                        {
                            Id = 14,
                            Amount = 20,
                            Category = "Đồ ăn",
                            Description = "Snack",
                            Image = "ms-appx:///Assets/snack.jpg",
                            Name = "Snack",
                            Price = 10000m
                        },
                        new
                        {
                            Id = 15,
                            Amount = 20,
                            Category = "Đồ ăn",
                            Description = "Đậu phộng",
                            Image = "ms-appx:///Assets/dauphong.jpg",
                            Name = "Đậu phộng",
                            Price = 10000m
                        },
                        new
                        {
                            Id = 16,
                            Amount = 20,
                            Category = "Đồ ăn",
                            Description = "Hạt hướng dương",
                            Image = "ms-appx:///Assets/huongduong.jpg",
                            Name = "Hạt hướng dương",
                            Price = 10000m
                        });
                });

            modelBuilder.Entity("POS_Coffee.Models.PaymentDetailModel", b =>
                {
                    b.Property<Guid>("PaymentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("PaymentID", "FoodId");

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("POS_Coffee.Models.PaymentModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AmountReceived")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Change")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("PaymetMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceAfterDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("POS_Coffee.Models.StockModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("StockNumber")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Cà phê thương hiệu Trung Nguyên Legend",
                            ImagePath = "ms-appx:///Assets/trungnguyen.jpg",
                            Name = "Cà phê",
                            Price = 80000,
                            StockNumber = 0,
                            Unit = "kg"
                        },
                        new
                        {
                            ID = 2,
                            Description = "Sữa tươi Vinamilk 100% nguyên chất",
                            ImagePath = "ms-appx:///Assets/Vinamilk.jpg",
                            Name = "Sữa tươi",
                            Price = 40000,
                            StockNumber = 10,
                            Unit = "hộp"
                        },
                        new
                        {
                            ID = 3,
                            Description = "Trứng gà công nghiệp",
                            ImagePath = "ms-appx:///Assets/trungga.jpg",
                            Name = "Trứng gà",
                            Price = 3000,
                            StockNumber = 50,
                            Unit = "quả"
                        },
                        new
                        {
                            ID = 4,
                            Description = "Sữa đặc Ông thọ",
                            ImagePath = "ms-appx:///Assets/ongtho.jpg",
                            Name = "Sữa đặc",
                            Price = 22000,
                            StockNumber = 5,
                            Unit = "hộp"
                        },
                        new
                        {
                            ID = 5,
                            Description = "Trà thái nguyên",
                            ImagePath = "ms-appx:///Assets/trathainguyen.jpg",
                            Name = "Trà",
                            Price = 60000,
                            StockNumber = 20,
                            Unit = "kg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
