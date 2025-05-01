using ParkBuddy.Application.Common;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Domain.Repositories
{
    public interface IParkingRepository
    {
        Task<Result<List<Parking>>> GetParkingListAsync();
        Task<Result<Parking>> GetParkingAsync();
        Task<Result<string>> DeleteParkingAsync(Guid parkingId);
        Task<Result<bool>> RegisterParkingAsync(Parking parking);
    }
}