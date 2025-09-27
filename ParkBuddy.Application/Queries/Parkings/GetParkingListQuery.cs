using MediatR;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Queries.Parkings
{
    public record GetParkingListQuery() : IRequest<Result<GetParkingListQueryResult>>;
}