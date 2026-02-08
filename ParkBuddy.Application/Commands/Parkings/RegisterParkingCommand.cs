using MediatR;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Application.Commands.Parkings;

/// <summary>
/// Represents a command to register a new parking with the specified details.
/// </summary>
/// <param name="Name">Parking name.</param>
/// <param name="Address">Address of parking.</param>
/// <param name="Capacity">Vehicle capacity.</param>
/// <param name="PricePerHour">Price per hour.</param>
public record RegisterParkingCommand(
    string Name,
    Address Address,
    int Capacity,
    decimal PricePerHour) : IRequest<Result<Guid>>;
