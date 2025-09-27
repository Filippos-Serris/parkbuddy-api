using MediatR;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Queries.Parkings
{
    public class GetParkingQuery : IRequest<Result<GetParkingQueryResult>>
    {
        public Guid ParkingId { get; set; }

        public GetParkingQuery(Guid parkingId)
        {
            ParkingId = parkingId;
        }
    }
}
