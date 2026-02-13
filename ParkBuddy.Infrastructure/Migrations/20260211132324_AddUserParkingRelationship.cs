using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParkBuddy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserParkingRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Parkings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_UserId",
                table: "Parkings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_AspNetUsers_UserId",
                table: "Parkings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_AspNetUsers_UserId",
                table: "Parkings");

            migrationBuilder.DropIndex(
                name: "IX_Parkings_UserId",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Parkings");

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "ParkingId", "Capacity", "Name", "PricePerHour", "Status", "StreetNumber", "PostalCode", "StreetName" },
                values: new object[,]
                {
                    { new Guid("a1f4b29a-8b2e-4a89-a67e-1c4f85b62b29"), 100, "Downtown Parking", 5.00m, 0, "City Center", "12345", "123 Main St" },
                    { new Guid("b3e2c68d-4f9c-4d2a-9f25-77f29f2d3c3f"), 150, "Mall Parking", 3.50m, 0, "Mall Area", "67890", "456 Shopping Ave" },
                    { new Guid("c2d1f4e5-1e0a-4d98-9e3b-6c5b2a7f8a4d"), 200, "Airport Parking", 7.00m, 0, "Near Terminal", "54321", "789 Airport Rd" }
                });
        }
    }
}
