using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Coffee.Migrations
{
    /// <inheritdoc />
    public partial class updateforeignkeypaymentdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_FoodId",
                table: "PaymentDetails",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_Foods_FoodId",
                table: "PaymentDetails",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_Foods_FoodId",
                table: "PaymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDetails_FoodId",
                table: "PaymentDetails");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 8, 11, 5, 15, 762, DateTimeKind.Local).AddTicks(3263), new DateTime(2024, 12, 8, 11, 5, 15, 764, DateTimeKind.Local).AddTicks(2164) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 8, 11, 5, 15, 764, DateTimeKind.Local).AddTicks(3153), new DateTime(2024, 12, 8, 11, 5, 15, 764, DateTimeKind.Local).AddTicks(3157) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2024, 12, 8, 11, 5, 15, 764, DateTimeKind.Local).AddTicks(3161), new DateTime(2024, 12, 8, 11, 5, 15, 764, DateTimeKind.Local).AddTicks(3162) });
        }
    }
}
