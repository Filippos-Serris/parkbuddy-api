using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Application.Dtos.Parkings
{
    /// <summary>
    /// Represents a data transfer object (DTO) for parking information in a list format.
    /// </summary>
    /// <param name="Id">The unique identifier of the parking.</param>
    /// <param name="Name">The name of the parking.</param>
    /// <param name="Address">The address of the parking.</param>
    /// <param name="PricePerHour">The price per hour for the parking.</param>
    /// <param name="Status">The status of the parking (Open, Closed, Full).</param>
    public record ParkingListDto(Guid Id,
    string Name,
    Address Address,
    decimal PricePerHour,
    ParkingStatus Status);
}