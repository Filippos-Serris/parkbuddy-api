using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;

namespace ParkBuddy.Application.Interfaces
{
    public interface IParkingMediatorService
    {
        Task<Result<List<ParkingDto>>> GetParkings();
        Task<Result<ParkingDto>> GetParking(Guid parkingId);
        Task<Result<Guid>> RegisterParking(RegisterParkingDto parking);
        Task<Result<string>> DeleteParking(Guid parkingId);
        Task<Result<ParkingDto>> UpdateParking(UpdateParkingDto parking);
    }
}
