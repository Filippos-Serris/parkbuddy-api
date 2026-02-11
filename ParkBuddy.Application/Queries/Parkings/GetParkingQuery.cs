using MediatR;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Queries.Parkings;

/// <summary>
/// Represents a query to retrieve detailed information about a specific parking by its ID.
/// </summary>
public record GetParkingQuery(Guid ParkingId) : IRequest<Result<ParkingDto>>
{
    /// <summary>
    /// Gets or sets the parking ID for which to retrieve details.
    /// </summary>
    public Guid ParkingId { get; set; } = ParkingId;
}
