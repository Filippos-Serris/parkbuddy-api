using MediatR;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Application.Commands.Parkings
{
    public record RegisterParkingCommand(
        string Name,
        Address Address,
        int Capacity,
        decimal PricePerHour) : IRequest<Result<Guid>>;
}
