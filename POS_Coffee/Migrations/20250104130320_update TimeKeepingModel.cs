using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Coffee.Migrations
{
    /// <inheritdoc />
    public partial class updateTimeKeepingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeKeppingModels",
                table: "TimeKeppingModels");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "EndTime",
                table: "TimeKeppingModels",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartTime",
                table: "TimeKeppingModels",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateOnly>(
                name: "WorkDate",
                table: "TimeKeppingModels",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeKeppingModels",
                table: "TimeKeppingModels",
                columns: new[] { "EmployeeID", "WorkDate" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeKeppingModels",
                table: "TimeKeppingModels");

            migrationBuilder.DropColumn(
                name: "WorkDate",
                table: "TimeKeppingModels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "TimeKeppingModels",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "TimeKeppingModels",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeKeppingModels",
                table: "TimeKeppingModels",
                columns: new[] { "EmployeeID", "StartTime" });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2025, 1, 4, 17, 56, 58, 342, DateTimeKind.Local).AddTicks(3867), new DateTime(2025, 1, 4, 17, 56, 58, 343, DateTimeKind.Local).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2025, 1, 4, 17, 56, 58, 343, DateTimeKind.Local).AddTicks(4429), new DateTime(2025, 1, 4, 17, 56, 58, 343, DateTimeKind.Local).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2025, 1, 4, 17, 56, 58, 343, DateTimeKind.Local).AddTicks(4434), new DateTime(2025, 1, 4, 17, 56, 58, 343, DateTimeKind.Local).AddTicks(4435) });
        }
    }
}
