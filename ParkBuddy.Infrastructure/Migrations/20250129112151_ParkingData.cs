using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParkBuddy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ParkingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("5090b833-7a15-49f9-8b85-95787d7bdc48"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("82a5e7e2-91c2-42ce-a970-bffcd7f25d48"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("f9a2bf7a-c897-4a72-b123-3238b357d61e"));

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "ParkingId", "Address", "Capacity", "Name", "PricePerHour" },
                values: new object[,]
                {
                    { new Guid("a1f4b29a-8b2e-4a89-a67e-1c4f85b62b29"), "123 Main St, City Center", 100, "Downtown Parking", 5.00m },
                    { new Guid("b3e2c68d-4f9c-4d2a-9f25-77f29f2d3c3f"), "456 Shopping Ave, Mall Area", 150, "Mall Parking", 3.50m },
                    { new Guid("c2d1f4e5-1e0a-4d98-9e3b-6c5b2a7f8a4d"), "789 Airport Rd, Near Terminal", 200, "Airport Parking", 7.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("a1f4b29a-8b2e-4a89-a67e-1c4f85b62b29"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("b3e2c68d-4f9c-4d2a-9f25-77f29f2d3c3f"));

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("c2d1f4e5-1e0a-4d98-9e3b-6c5b2a7f8a4d"));

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "ParkingId", "Address", "Capacity", "Name", "PricePerHour" },
                values: new object[,]
                {
                    { new Guid("5090b833-7a15-49f9-8b85-95787d7bdc48"), "123 Main St, City Center", 100, "Downtown Parking", 5.00m },
                    { new Guid("82a5e7e2-91c2-42ce-a970-bffcd7f25d48"), "789 Airport Rd, Near Terminal", 200, "Airport Parking", 7.00m },
                    { new Guid("f9a2bf7a-c897-4a72-b123-3238b357d61e"), "456 Shopping Ave, Mall Area", 150, "Mall Parking", 3.50m }
                });
        }
    }
}
