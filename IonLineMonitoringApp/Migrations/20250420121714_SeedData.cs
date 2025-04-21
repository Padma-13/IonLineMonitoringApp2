using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IonLineMonitoringApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalEnergy",
                table: "ShiftDatas",
                newName: "TotalEnergy");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "TotalEnergy",
                table: "ShiftDatas",
                newName: "TotalEnergy");
        }
    }
}
