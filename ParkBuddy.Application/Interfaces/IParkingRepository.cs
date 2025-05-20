using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;

namespace ParkBuddy.Application.Interfaces
{
    public interface IParkingRepository
    {
        Task<Result<List<ParkingDto>>> GetParkingListAsync();
        Task<Result<ParkingDto>> GetParkingAsync(Guid parkingId);
        Task<Result<Guid>> RegisterParkingAsync(RegisterParkingDto parking);
        Task<Result<string>> DeleteParkingAsync(Guid parkingId);
        Task<Result<ParkingDto>> UpdateParkingAsync(UpdateParkingDto parking);
    }
}