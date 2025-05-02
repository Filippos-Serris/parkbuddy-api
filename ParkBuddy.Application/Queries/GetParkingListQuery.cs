using MediatR;
using ParkBuddy.Application.Common;
using ParkBuddy.Application.Dtos;

namespace ParkBuddy.Application.Queries
{
    public class GetParkingListQuery : IRequest<Result<List<ParkingDto>>>
    {

    }
}