using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace POS_Coffee.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountReceived = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceAfterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymetMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StockNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CartItemModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItemModel_Payments_PaymentModelId",
                        column: x => x.PaymentModelId,
                        principalTable: "Payments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "password", "role", "username" },
                values: new object[,]
                {
                    { 1, "emp1", "employee", "emp1" },
                    { 2, "emp2", "employee", "emp2" },
                    { 3, "admin1", "admin", "admin1" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Amount", "Category", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 12, "Đồ uống", "Nước pepsi", "ms-appx:///Assets/pepsi.webp", "Pepsi", 14000m },
                    { 2, 10, "Đồ uống", "Cà phê đen đá", "ms-appx:///Assets/coffee.jpg", "Cà phê đá", 10000m },
                    { 3, 10, "Đồ uống", "Bạc xỉu", "ms-appx:///Assets/bac-xiu.jpg", "Bạc xỉu", 20000m },
                    { 4, 10, "Đồ uống", "Cà phê muối", "ms-appx:///Assets/coffee-salt.jpg", "Cà phê muối", 25000m },
                    { 5, 15, "Đồ uống", "Trà sữa trân châu đường đen", "ms-appx:///Assets/milktea.jpg", "Trà sữa", 25000m },
                    { 6, 12, "Đồ uống", "Trà chanh", "ms-appx:///Assets/tra-chanh.jpg", "Trà chanh", 14000m },
                    { 7, 12, "Đồ uống", "Nước revive", "ms-appx:///Assets/revive.webp", "Revive", 10000m },
                    { 8, 15, "Đồ uống", "Sữa chua việt quất", "ms-appx:///Assets/suachua-vietquat.jpg", "Sữa chua việt quất", 25000m },
                    { 9, 15, "Đồ uống", "Sữa chua đá", "ms-appx:///Assets/suachua-da.jpg", "Sữa chua đá", 25000m },
                    { 10, 15, "Đồ uống", "Sinh tố bơ", "ms-appx:///Assets/sinhto-bo.jpg", "Sinh tố bơ", 25000m },
                    { 11, 10, "Đồ ăn", "Mì tôm", "ms-appx:///Assets/Omachi.jfif", "Mì Omachi", 20000m },
                    { 12, 20, "Đồ ăn", "Mì tôm", "ms-appx:///Assets/HaoHao.jfif", "Mì Hảo Hảo", 15000m },
                    { 13, 20, "Đồ ăn", "Bánh mì ngọt", "ms-appx:///Assets/banhmingot.jpg", "Bánh mì ngọt", 15000m },
                    { 14, 20, "Đồ ăn", "Snack", "ms-appx:///Assets/snack.jpg", "Snack", 10000m },
                    { 15, 20, "Đồ ăn", "Đậu phộng", "ms-appx:///Assets/dauphong.jpg", "Đậu phộng", 10000m },
                    { 16, 20, "Đồ ăn", "Hạt hướng dương", "ms-appx:///Assets/huongduong.jpg", "Hạt hướng dương", 10000m }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "ID", "Description", "ImagePath", "Name", "Price", "StockNumber", "Unit" },
                values: new object[,]
                {
                    { 1, "Cà phê thương hiệu Trung Nguyên Legend", "ms-appx:///Assets/trungnguyen.jpg", "Cà phê", 80000, 0, "kg" },
                    { 2, "Sữa tươi Vinamilk 100% nguyên chất", "ms-appx:///Assets/Vinamilk.jpg", "Sữa tươi", 40000, 10, "hộp" },
                    { 3, "Trứng gà công nghiệp", "ms-appx:///Assets/trungga.jpg", "Trứng gà", 3000, 50, "quả" },
                    { 4, "Sữa đặc Ông thọ", "ms-appx:///Assets/ongtho.jpg", "Sữa đặc", 22000, 5, "hộp" },
                    { 5, "Trà thái nguyên", "ms-appx:///Assets/trathainguyen.jpg", "Trà", 60000, 20, "kg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItemModel_PaymentModelId",
                table: "CartItemModel",
                column: "PaymentModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CartItemModel");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
