using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.Entities;

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
            });
        });
    }
}