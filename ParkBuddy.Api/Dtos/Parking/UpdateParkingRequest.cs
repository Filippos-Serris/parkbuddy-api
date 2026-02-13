using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Api.Dtos.Parking;

/// <summary>
/// Represents a request to update an existing parking with the specified details.
/// </summary>
/// <param name="Name">Parking name.</param>
/// <param name="Address">Address of parking.</param>
/// <param name="Capacity">Vehicle capacity.</param>
/// <param name="PricePerHour">Price per hour.</param>
/// <param name="Status">Status of parking (Open, Closed, Full).</param>
public record UpdateParkingRequest(
    string Name,
    Address Address,
    int Capacity,
    decimal PricePerHour,
    ParkingStatus Status)
{
}
