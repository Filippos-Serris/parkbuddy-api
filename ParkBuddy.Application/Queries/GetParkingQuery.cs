using MediatR;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;

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
