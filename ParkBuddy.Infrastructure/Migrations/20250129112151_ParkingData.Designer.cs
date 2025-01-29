﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ParkBuddy.Infrastructure.Data;

#nullable disable

namespace ParkBuddy.Infrastructure.Migrations
{
    [DbContext(typeof(ParkBuddyContext))]
    [Migration("20250129112151_ParkingData")]
    partial class ParkingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ParkBuddy.Domain.Entities.Parking", b =>
                {
                    b.Property<Guid>("ParkingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("numeric");

                    b.HasKey("ParkingId");

                    b.ToTable("Parkings");

                    b.HasData(
                        new
                        {
                            ParkingId = new Guid("a1f4b29a-8b2e-4a89-a67e-1c4f85b62b29"),
                            Address = "123 Main St, City Center",
                            Capacity = 100,
                            Name = "Downtown Parking",
                            PricePerHour = 5.00m
                        },
                        new
                        {
                            ParkingId = new Guid("b3e2c68d-4f9c-4d2a-9f25-77f29f2d3c3f"),
                            Address = "456 Shopping Ave, Mall Area",
                            Capacity = 150,
                            Name = "Mall Parking",
                            PricePerHour = 3.50m
                        },
                        new
                        {
                            ParkingId = new Guid("c2d1f4e5-1e0a-4d98-9e3b-6c5b2a7f8a4d"),
                            Address = "789 Airport Rd, Near Terminal",
                            Capacity = 200,
                            Name = "Airport Parking",
                            PricePerHour = 7.00m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
