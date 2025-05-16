using MediatR;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;

namespace ParkBuddy.Application.Queries
{
    public class GetParkingListQuery : IRequest<Result<List<ParkingDto>>>
    {

    }
}