using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Application.Queries.Parkings;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Interfaces
{
    public interface IParkingMediatorService
    {
        Task<Result<GetParkingListQueryResult>> GetParkings();
        Task<Result<GetParkingQueryResult>> GetParking(Guid parkingId);
        Task<Result<Guid>> RegisterParking(RegisterParkingCommand parking);
        Task<Result<bool>> DeleteParking(Guid parkingId);
        Task<Result<ParkingDto>> UpdateParking(UpdateParkingCommand parking);
    }
}
