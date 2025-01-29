using Microsoft.EntityFrameworkCore;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Infrastructure.Data
{
    public class ParkBuddyContext : DbContext
    {
        public ParkBuddyContext(DbContextOptions options) : base(options) { }

        public DbSet<Parking> Parkings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Parking>().HasData(
                new Parking
                {
                    ParkingId = new Guid("a1f4b29a-8b2e-4a89-a67e-1c4f85b62b29"),
                    Name = "Downtown Parking",
                    Address = "123 Main St, City Center",
                    Capacity = 100,
                    PricePerHour = 5.00m
                },
                new Parking
                {
                    ParkingId = new Guid("b3e2c68d-4f9c-4d2a-9f25-77f29f2d3c3f"),
                    Name = "Mall Parking",
                    Address = "456 Shopping Ave, Mall Area",
                    Capacity = 150,
                    PricePerHour = 3.50m
                },
                new Parking
                {
                    ParkingId = new Guid("c2d1f4e5-1e0a-4d98-9e3b-6c5b2a7f8a4d"),
                    Name = "Airport Parking",
                    Address = "789 Airport Rd, Near Terminal",
                    Capacity = 200,
                    PricePerHour = 7.00m
                }
            );
        }
    }
}