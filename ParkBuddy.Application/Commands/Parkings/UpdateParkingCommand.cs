using MediatR;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Application.Commands.Parkings;

/// <summary>
/// Represents a command to update an existing parking with the specified details.
/// </summary>
/// <param name="Id">The ID of the parking to update.</param>
/// <param name="Name">The updated name of the parking.</param>
/// <param name="Address">The updated address of the parking.</param>
/// <param name="Capacity">The updated capacity of the parking.</param>
/// <param name="PricePerHour">The updated price per hour for the parking.</param>
/// <param name="Status">The updated status of the parking.</param>
public record UpdateParkingCommand(
    Guid Id,
    string Name,
    Address Address,
    int Capacity,
    decimal PricePerHour,
    ParkingStatus Status) : IRequest<Result<ParkingDto>>;
