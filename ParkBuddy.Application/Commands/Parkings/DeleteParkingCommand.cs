using MediatR;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Commands.Parkings;

/// <summary>
/// Represents a command to delete a parking with the specified parking ID.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DeleteParkingCommand"/> class.
/// </remarks>
/// <param name="parkingId">Parking id for deletion.</param>
public class DeleteParkingCommand(Guid parkingId) : IRequest<Result<bool>>
{
    /// <summary>
    /// Gets or sets the parking ID for deletion.
    /// </summary>
    public Guid ParkingId { get; set; } = parkingId;
}
