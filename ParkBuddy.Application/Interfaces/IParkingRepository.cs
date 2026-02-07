using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Contracts.Common;


namespace ParkBuddy.Application.Interfaces;

public interface IParkingRepository
{
    Task<Result<List<ParkingListDto>>> GetParkingListAsync(CancellationToken cancellationToken);
    Task<Result<ParkingDto>> GetParkingAsync(Guid parkingId, CancellationToken cancellationToken);
    Task<Result<Guid>> RegisterParkingAsync(RegisterParkingCommand parking, CancellationToken cancellationToken);
    Task<Result<bool>> DeleteParkingAsync(Guid parkingId, CancellationToken cancellationToken);
    Task<Result<ParkingDto>> UpdateParkingAsync(UpdateParkingCommand parking, CancellationToken cancellationToken);
}