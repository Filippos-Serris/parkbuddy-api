using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;

namespace ParkBuddy.Infrastructure.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ParkBuddyContext context;

        public ParkingRepository(ParkBuddyContext context)
        {
            this.context = context;
        }

        public async Task<Result<List<Parking>>> GetParkingListAsync()
        {
            var result = await context.Parkings.
                ToListAsync();

            if (result == null)
                return Result<List<Parking>>.Failure("Parkings not retrieved.");
            return Result<List<Parking>>.Success(result, "Parkings retrieved succeffully");
        }

        public async Task<Result<Parking>> GetParkingAsync(Guid ParkingId)
        {
            var result = await context.Parkings.FindAsync(ParkingId);

            if (result == null)
                return Result<Parking>.Failure("Parking not retrieved.");
            return Result<Parking>.Success(result, "Parking retrieved succeffully");
        }

        public async Task<Result<Guid>> RegisterParkingAsync(RegisterParkingDto parking)
        {

            var newParking = new Parking
            {
                ParkingId = Guid.NewGuid(),
                Name = parking.Name,
                Address = parking.Address,
                Capacity = parking.Capacity,
                PricePerHour = parking.PricePerHour
            };

            context.Add(newParking);
            var result = await context.SaveChangesAsync() > 0;

            if (result)
                return Result<Guid>.Success(newParking.ParkingId, "Parkign registered successfully");
            return Result<Guid>.Failure("Failed to register parking");
        }

        public async Task<Result<string>> DeleteParkingAsync(Guid parkingId)
        {
            var result = await context.Parkings.Where(p => p.ParkingId == parkingId).ExecuteDeleteAsync() > 0;

            if (result)
                return Result<string>.Success("Deleted", "Parking deleted successfully");
            return Result<string>.Failure("Failed to delete parking");
        }
    }
}
