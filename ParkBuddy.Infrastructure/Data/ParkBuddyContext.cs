using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Infrastructure.Data;

public class ParkBuddyContext : IdentityDbContext<User, IdentityRole<Guid>, Guid> // <UserEntity, RoleEtity<PK used by role>, PK used by Entity>
{
    public ParkBuddyContext(DbContextOptions<ParkBuddyContext> options) : base(options) { }

    public DbSet<Parking> Parkings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Parking>(entity =>
        {
            entity.HasKey(p => p.ParkingId);

            // Configure the Address value object as owned
            entity.OwnsOne(p => p.Address, address =>
            {
                address.Property(a => a.StreetName).HasColumnName("StreetName").IsRequired();
                address.Property(a => a.Number).HasColumnName("StreetNumber").IsRequired();
                address.Property(a => a.PostalCode).HasColumnName("PostalCode").IsRequired();

                // Seed data for Address (owned type)
                address.HasData(
                    new
                    {
                        ParkingId = new Guid("a1f4b29a-8b2e-4a89-a67e-1c4f85b62b29"), // Foreign key (Id)
                        StreetName = "123 Main St",
                        Number = "City Center",
                        PostalCode = "12345"
                    },
                    new
                    {
                        ParkingId = new Guid("b3e2c68d-4f9c-4d2a-9f25-77f29f2d3c3f"), // Foreign key (Id)
                        StreetName = "456 Shopping Ave",
                        Number = "Mall Area",
                        PostalCode = "67890"
                    },
                    new
                    {
                        ParkingId = new Guid("c2d1f4e5-1e0a-4d98-9e3b-6c5b2a7f8a4d"), // Foreign key (Id)
                        StreetName = "789 Airport Rd",
                        Number = "Near Terminal",
                        PostalCode = "54321"
                    }
                );
            });

            // Seed data for Parking
            entity.HasData(
                new
                {
                    ParkingId = new Guid("a1f4b29a-8b2e-4a89-a67e-1c4f85b62b29"),
                    Name = "Downtown Parking",
                    Capacity = 100,
                    PricePerHour = 5.00m,
                    Status = ParkingStatus.Open
                },
                new
                {
                    ParkingId = new Guid("b3e2c68d-4f9c-4d2a-9f25-77f29f2d3c3f"),
                    Name = "Mall Parking",
                    Capacity = 150,
                    PricePerHour = 3.50m,
                    Status = ParkingStatus.Open
                },
                new
                {
                    ParkingId = new Guid("c2d1f4e5-1e0a-4d98-9e3b-6c5b2a7f8a4d"),
                    Name = "Airport Parking",
                    Capacity = 200,
                    PricePerHour = 7.00m,
                    Status = ParkingStatus.Open
                }
            );
        });
    }
}