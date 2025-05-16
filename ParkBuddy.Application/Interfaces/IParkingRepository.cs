using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Application.Interfaces
{
    public interface IParkingRepository
    {
        Task<Result<List<ParkingDto>>> GetParkingListAsync();
        Task<Result<ParkingDto>> GetParkingAsync(Guid parkingId);
        Task<Result<Guid>> RegisterParkingAsync(RegisterParkingDto parking);
        Task<Result<string>> DeleteParkingAsync(Guid parkingId);
    }
}