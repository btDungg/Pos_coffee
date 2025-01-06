using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Coffee.Migrations
{
    /// <inheritdoc />
    public partial class addisActiveattribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2025, 1, 6, 14, 16, 25, 202, DateTimeKind.Local).AddTicks(5475), new DateTime(2025, 1, 6, 14, 16, 25, 204, DateTimeKind.Local).AddTicks(2674) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2025, 1, 6, 14, 16, 25, 204, DateTimeKind.Local).AddTicks(3155), new DateTime(2025, 1, 6, 14, 16, 25, 204, DateTimeKind.Local).AddTicks(3156) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2025, 1, 6, 14, 16, 25, 204, DateTimeKind.Local).AddTicks(3161), new DateTime(2025, 1, 6, 14, 16, 25, 204, DateTimeKind.Local).AddTicks(3162) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2025, 1, 4, 20, 3, 20, 109, DateTimeKind.Local).AddTicks(2044), new DateTime(2025, 1, 4, 20, 3, 20, 110, DateTimeKind.Local).AddTicks(7102) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2025, 1, 4, 20, 3, 20, 110, DateTimeKind.Local).AddTicks(7767), new DateTime(2025, 1, 4, 20, 3, 20, 110, DateTimeKind.Local).AddTicks(7769) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2025, 1, 4, 20, 3, 20, 110, DateTimeKind.Local).AddTicks(7774), new DateTime(2025, 1, 4, 20, 3, 20, 110, DateTimeKind.Local).AddTicks(7775) });
        }
    }
}
