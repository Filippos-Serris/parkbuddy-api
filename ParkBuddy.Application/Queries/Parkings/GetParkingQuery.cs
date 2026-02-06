using MediatR;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Queries.Parkings;

public class GetParkingQuery : IRequest<Result<ParkingDto>>
{
    public Guid ParkingId { get; set; }

    public GetParkingQuery(Guid parkingId)
    {
        ParkingId = parkingId;
    }
}
