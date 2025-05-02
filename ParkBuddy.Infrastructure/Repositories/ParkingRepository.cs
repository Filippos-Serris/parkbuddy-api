using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Common;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Domain.Repositories;
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
            var result = await context.Parkings.ToListAsync();

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

        public async Task<Result<string>> DeleteParkingAsync(Guid parkingId)
        {
            var result = await context.Parkings.Where(p => p.ParkingId == parkingId).ExecuteDeleteAsync() > 0;
            return result
                ? Result<string>.Success("Deleted", "Parking deleted successfully")
                : Result<string>.Failure("Failed to delete parking");
        }

        public Task<Result<bool>> RegisterParkingAsync(Parking parking)
        {
            throw new NotImplementedException();
        }
    }
}
