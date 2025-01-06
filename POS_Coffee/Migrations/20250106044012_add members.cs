using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace POS_Coffee.Migrations
{
    /// <inheritdoc />
    public partial class addmembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    phoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.phoneNumber);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "phoneNumber", "Name", "point" },
                values: new object[,]
                {
                    { "0112345678", "Phạm Thế Duyệt", 50 },
                    { "0123456789", "Bùi Tiến Dũng", 100 },
                    { "0987654321", "Nguyễn Võ Nhật Duy", 10 }
                });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "applicable_to", "created_date", "updated_date" },
                values: new object[] { "Tất cả sản phẩm", new DateTime(2025, 1, 6, 11, 40, 10, 635, DateTimeKind.Local).AddTicks(9282), new DateTime(2025, 1, 6, 11, 40, 10, 636, DateTimeKind.Local).AddTicks(8163) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "applicable_to", "created_date", "discount_type", "updated_date" },
                values: new object[] { "Tất cả sản phẩm", new DateTime(2025, 1, 6, 11, 40, 10, 636, DateTimeKind.Local).AddTicks(8614), "Số tiền cố định", new DateTime(2025, 1, 6, 11, 40, 10, 636, DateTimeKind.Local).AddTicks(8616) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "applicable_to", "created_date", "discount_type", "updated_date" },
                values: new object[] { "Tất cả sản phẩm", new DateTime(2025, 1, 6, 11, 40, 10, 636, DateTimeKind.Local).AddTicks(8619), "Phần trăm", new DateTime(2025, 1, 6, 11, 40, 10, 636, DateTimeKind.Local).AddTicks(8620) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "applicable_to", "created_date", "updated_date" },
                values: new object[] { "all", new DateTime(2025, 1, 4, 20, 3, 20, 109, DateTimeKind.Local).AddTicks(2044), new DateTime(2025, 1, 4, 20, 3, 20, 110, DateTimeKind.Local).AddTicks(7102) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "applicable_to", "created_date", "discount_type", "updated_date" },
                values: new object[] { "all", new DateTime(2025, 1, 4, 20, 3, 20, 110, DateTimeKind.Local).AddTicks(7767), "amount", new DateTime(2025, 1, 4, 20, 3, 20, 110, DateTimeKind.Local).AddTicks(7769) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "applicable_to", "created_date", "discount_type", "updated_date" },
                values: new object[] { "categories", new DateTime(2025, 1, 4, 20, 3, 20, 110, DateTimeKind.Local).AddTicks(7774), "percent", new DateTime(2025, 1, 4, 20, 3, 20, 110, DateTimeKind.Local).AddTicks(7775) });
        }
    }
}
