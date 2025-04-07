using MediatR;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Application.Queries
{
    public class ParkingListQuery : IRequest<List<Parking>>
    {

    }
}