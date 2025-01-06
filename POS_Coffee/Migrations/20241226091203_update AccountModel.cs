using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Coffee.Migrations
{
    /// <inheritdoc />
    public partial class updateAccountModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "address", "email", "phone" },
                values: new object[] { "Thủ Đức, TP Hồ Chí Minh", "emp1@gmail.com", "0123456789" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "address", "email", "phone" },
                values: new object[] { "Đông Hòa, Dĩ An, Bình Dương", "emp2@gmail.com", "0805057891" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "address", "email", "phone" },
                values: new object[] { "Thủ Đức, TP Hồ Chí Minh", "admin1@gmail.com", "0159753214" });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 26, 16, 12, 0, 767, DateTimeKind.Local).AddTicks(2852), new DateTime(2024, 12, 26, 16, 12, 0, 768, DateTimeKind.Local).AddTicks(3031) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 26, 16, 12, 0, 768, DateTimeKind.Local).AddTicks(4582), new DateTime(2024, 12, 26, 16, 12, 0, 768, DateTimeKind.Local).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 26, 16, 12, 0, 768, DateTimeKind.Local).AddTicks(4593), new DateTime(2024, 12, 26, 16, 12, 0, 768, DateTimeKind.Local).AddTicks(4594) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 16, 16, 15, 6, 317, DateTimeKind.Local).AddTicks(1828), new DateTime(2024, 12, 16, 16, 15, 6, 318, DateTimeKind.Local).AddTicks(6357) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 16, 16, 15, 6, 318, DateTimeKind.Local).AddTicks(6940), new DateTime(2024, 12, 16, 16, 15, 6, 318, DateTimeKind.Local).AddTicks(6941) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 16, 16, 15, 6, 318, DateTimeKind.Local).AddTicks(6947), new DateTime(2024, 12, 16, 16, 15, 6, 318, DateTimeKind.Local).AddTicks(6947) });
        }
    }
}
