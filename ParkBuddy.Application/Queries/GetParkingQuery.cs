using MediatR;
using ParkBuddy.Application.Common;
using ParkBuddy.Application.Dtos;

namespace ParkBuddy.Application.Queries
{
    public class GetParkingQuery : IRequest<Result<ParkingDto>>
    {
        public Guid ParkingId { get; set; }

        public GetParkingQuery(Guid parkingId)
        {
            ParkingId = parkingId;
        }
    }
}
