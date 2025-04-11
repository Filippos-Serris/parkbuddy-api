using MediatR;
using ParkBuddy.Application.Dtos;

namespace ParkBuddy.Application.Queries
{
    public class GetParkingQuery : IRequest<ParkingDto>
    {
        public Guid ParkingId { get; set; }

        public GetParkingQuery(Guid parkingId)
        {
            ParkingId = parkingId;
        }
    }
}
