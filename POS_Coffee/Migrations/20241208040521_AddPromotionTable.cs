using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace POS_Coffee.Migrations
{
    /// <inheritdoc />
    public partial class AddPromotionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    discount_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    discount_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    min_order_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    applicable_to = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Description", "Name", "applicable_to", "created_by", "created_date", "discount_type", "discount_value", "end_date", "is_active", "min_order_value", "start_date", "updated_by", "updated_date" },
                values: new object[,]
                {
                    { 1, "Khuyến mãi áp dụng từ 01/01/2024 đến 31/01/2024", "Giảm 10% cho hóa đơn lớn hơn 500,000", "all", 3, new DateTime(2024, 12, 8, 11, 5, 15, 762, DateTimeKind.Local).AddTicks(3263), "percent", 10m, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2024, 12, 8, 11, 5, 15, 764, DateTimeKind.Local).AddTicks(2164) },
                    { 2, "Khuyến mãi cho tất cả đơn hàng từ 15/12/2023 đến 31/12/2023", "Giảm 50,000 cho hóa đơn từ 300,000 trở lên", "all", 3, new DateTime(2024, 12, 8, 11, 5, 15, 764, DateTimeKind.Local).AddTicks(3153), "amount", 50000m, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 300000m, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2024, 12, 8, 11, 5, 15, 764, DateTimeKind.Local).AddTicks(3157) },
                    { 3, "Khuyến mãi áp dụng riêng cho danh mục Đồ uống từ 01/02/2024 đến 28/02/2024", "Giảm giá 15% cho danh mục Đồ uống", "categories", 3, new DateTime(2024, 12, 8, 11, 5, 15, 764, DateTimeKind.Local).AddTicks(3161), "percent", 15m, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0m, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2024, 12, 8, 11, 5, 15, 764, DateTimeKind.Local).AddTicks(3162) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotions");
        }
    }
}
