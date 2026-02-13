using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Api.Dtos.Parking;

/// <summary>
/// Represents a request to register a new parking with the specified details.
/// </summary>
/// <param name="Name">Parking name.</param>
/// <param name="Address">Address of parking.</param>
/// <param name="Capacity">Vehicle capacity.</param>
/// <param name="PricePerHour">Price per hour.</param>
public record RegisterParkingRequest(
    string Name,
    Address Address,
    int Capacity,
    decimal PricePerHour);
