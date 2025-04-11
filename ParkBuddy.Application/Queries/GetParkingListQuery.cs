using MediatR;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Application.Queries
{
    public class GetParkingListQuery : IRequest<List<Parking>>
    {

    }
}