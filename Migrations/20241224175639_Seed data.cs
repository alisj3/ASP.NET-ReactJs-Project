using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3704a19b-efe7-4cf5-8051-a88fd675eb9d"), "Medium" },
                    { new Guid("6102c45a-cbff-4806-8876-3fee437cf485"), "Easy" },
                    { new Guid("d0a80614-636b-48aa-a43b-5ec1a87f0e73"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUtrl" },
                values: new object[,]
                {
                    { new Guid("531b20c2-822d-4df8-8469-2a8d3e5eeb77"), "AKL", "Auckland", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQqqBV7oCy4YvUtmrLJesTWoOsPIi-7vssBDw&s" },
                    { new Guid("672aa0a5-e0a3-41cd-872e-caacadf3b185"), "TA", "Tashkent", "https://trvlland.com/wp-content/uploads/2022/09/uzbekistan_tashkent-3-1024x663.jpg" },
                    { new Guid("b209acc1-305f-4058-88c2-aae307030405"), "ALA", "Almaty", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_Cp8ZXZ57NI1UN9Gw_9kuGsbO4jIPdhovJA&s" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3704a19b-efe7-4cf5-8051-a88fd675eb9d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6102c45a-cbff-4806-8876-3fee437cf485"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d0a80614-636b-48aa-a43b-5ec1a87f0e73"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("531b20c2-822d-4df8-8469-2a8d3e5eeb77"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("672aa0a5-e0a3-41cd-872e-caacadf3b185"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b209acc1-305f-4058-88c2-aae307030405"));
        }
    }
}
