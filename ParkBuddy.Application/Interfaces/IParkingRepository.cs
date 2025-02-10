using ParkBuddy.Application.Dtos;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Application.Interfaces
{
    public interface IParkingRepository
    {
        Task<Parking> GetParkingAsync(Guid parkingId);
        Task<List<Parking>> GetParkingsAsync();
        Task<Parking> RegisterParkingAsync(RegisterParkingDto parking);

        Task<bool> DeleteParkingAsync(Guid parkingId);
    }
}