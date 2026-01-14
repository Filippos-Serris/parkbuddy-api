using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Contracts.Common;


namespace ParkBuddy.Application.Interfaces
{
    public interface IParkingRepository
    {
        Task<Result<List<ParkingDto>>> GetParkingListAsync();
        Task<Result<ParkingDto>> GetParkingAsync(Guid parkingId);
        Task<Result<Guid>> RegisterParkingAsync(RegisterParkingCommand parking);
        Task<Result<bool>> DeleteParkingAsync(Guid parkingId);
        Task<Result<ParkingDto>> UpdateParkingAsync(UpdateParkingCommand parking);
    }
}