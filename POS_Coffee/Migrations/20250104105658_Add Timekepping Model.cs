using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Coffee.Migrations
{
    /// <inheritdoc />
    public partial class AddTimekeppingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeKeppingModels",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeKeppingModels", x => new { x.EmployeeID, x.StartTime });
                    table.ForeignKey(
                        name: "FK_TimeKeppingModels_Accounts_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeKeppingModels");

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
    }
}
