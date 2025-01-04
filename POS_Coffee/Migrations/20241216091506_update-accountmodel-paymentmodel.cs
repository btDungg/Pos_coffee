using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Coffee.Migrations
{
    /// <inheritdoc />
    public partial class updateaccountmodelpaymentmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "name",
                value: "Nguyễn Võ Nhật Huy");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "name",
                value: "Bùi Tiến Dũng");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "name",
                value: "Phạm Thế Duyệt");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 16, 15, 43, 36, 481, DateTimeKind.Local).AddTicks(8148), new DateTime(2024, 12, 16, 15, 43, 36, 482, DateTimeKind.Local).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 16, 15, 43, 36, 482, DateTimeKind.Local).AddTicks(9820), new DateTime(2024, 12, 16, 15, 43, 36, 482, DateTimeKind.Local).AddTicks(9821) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 16, 15, 43, 36, 482, DateTimeKind.Local).AddTicks(9826), new DateTime(2024, 12, 16, 15, 43, 36, 482, DateTimeKind.Local).AddTicks(9827) });
        }
    }
}
