using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkBuddy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddParkingStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Parkings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("a1f4b29a-8b2e-4a89-a67e-1c4f85b62b29"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("b3e2c68d-4f9c-4d2a-9f25-77f29f2d3c3f"),
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("c2d1f4e5-1e0a-4d98-9e3b-6c5b2a7f8a4d"),
                column: "Status",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Parkings");
        }
    }
}
