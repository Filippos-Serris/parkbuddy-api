using MediatR;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Application.Commands.Parkings;

public record UpdateParkingCommand(
    Guid Id,
    string Name,
    Address Address,
    int Capacity,
    decimal PricePerHour,
    ParkingStatus Status
    ) : IRequest<Result<ParkingDto>>
{ }
