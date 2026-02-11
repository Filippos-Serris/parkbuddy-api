using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkBuddy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Parkings",
                newName: "StreetNumber");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Parkings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "Parkings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("a1f4b29a-8b2e-4a89-a67e-1c4f85b62b29"),
                columns: new[] { "StreetNumber", "PostalCode", "StreetName" },
                values: new object[] { "City Center", "12345", "123 Main St" });

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("b3e2c68d-4f9c-4d2a-9f25-77f29f2d3c3f"),
                columns: new[] { "StreetNumber", "PostalCode", "StreetName" },
                values: new object[] { "Mall Area", "67890", "456 Shopping Ave" });

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("c2d1f4e5-1e0a-4d98-9e3b-6c5b2a7f8a4d"),
                columns: new[] { "StreetNumber", "PostalCode", "StreetName" },
                values: new object[] { "Near Terminal", "54321", "789 Airport Rd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "Parkings");

            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "Parkings",
                newName: "Address");

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("a1f4b29a-8b2e-4a89-a67e-1c4f85b62b29"),
                column: "Address",
                value: "123 Main St, City Center");

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("b3e2c68d-4f9c-4d2a-9f25-77f29f2d3c3f"),
                column: "Address",
                value: "456 Shopping Ave, Mall Area");

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "ParkingId",
                keyValue: new Guid("c2d1f4e5-1e0a-4d98-9e3b-6c5b2a7f8a4d"),
                column: "Address",
                value: "789 Airport Rd, Near Terminal");
        }
    }
}
