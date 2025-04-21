using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IonLineMonitoringApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedShiftData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "ShiftDatas",
                columns: new[] { "ShiftDataId", "Date", "LineId", "LineSpeed", "ProductId", "Shift", "TotalEnergy", "TotalProduction" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 120.0, 1, "A", 250.0, 500 },
                    { 2, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 100.0, 2, "B", 200.0, 400 },
                    { 3, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 110.0, 3, "C", 230.0, 450 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShiftDatas",
                keyColumn: "ShiftDataId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShiftDatas",
                keyColumn: "ShiftDataId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShiftDatas",
                keyColumn: "ShiftDataId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "LineId", "LineName" },
                values: new object[,]
                {
                    { 1, "L1" },
                    { 2, "L2" },
                    { 3, "L3" },
                    { 4, "L4" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName" },
                values: new object[,]
                {
                    { 1, "Product 1" },
                    { 2, "Product 2" },
                    { 3, "Product 3" },
                    { 4, "Product 4" },
                    { 5, "Product 5" }
                });
        }
    }
}
