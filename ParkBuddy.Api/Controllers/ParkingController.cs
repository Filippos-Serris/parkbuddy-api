using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Api.Dtos.Parking;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Queries.Parkings;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Contracts.Responses;

namespace ParkBuddy.Api.Controllers;

/// <summary>
/// Controller responsible for handling parking-related operations.
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]/")]
public class ParkingController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParkingController"/> class.
    /// </summary>
    /// <param name="mediator">Mediator.</param>
    public ParkingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Returns a list of available parkings.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpGet]
    [Authorize(Roles = "Customer,Admin")]
    public async Task<IActionResult> GetParkings(CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new GetParkingListQuery(), cancellationToken);

        if (!data.IsSuccess)
            return NotFound();

        var response = Result<GetParkingListResponse>.Success(
            new GetParkingListResponse(data.Data.Select(p => new ParkingListItem(
                    p.Id,
                    p.Name,
                    $"{p.Address.StreetName} {p.Address.Number}, {p.Address.PostalCode}",
                    p.PricePerHour,
                    p.Status.ToString()
                )).ToList()),
            data.Message);

        return Ok(response);
    }

    /// <summary>
    /// Get a specific parking based on the provided parkingId.
    /// </summary>
    /// <param name="parkingId">The id of the parking to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpGet]
    [Authorize(Roles = "Customer,Admin")]
    [Route("{parkingId}")]
    public async Task<IActionResult> GetParking([FromRoute] Guid parkingId, CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new GetParkingQuery(parkingId), cancellationToken);

        if (!data.IsSuccess)
            return NotFound();

        var response = Result<ParkingItem>.Success(
            new ParkingItem(
                data.Data.Id,
                data.Data.Name,
                $"{data.Data.Address.StreetName} {data.Data.Address.Number}, {data.Data.Address.PostalCode}",
                data.Data.Capacity,
                data.Data.PricePerHour,
                data.Data.Status),
            data.Message);

        return Ok(response);
    }

    /// <summary>
    /// Register a new parking.
    /// </summary>
    /// <param name="request">The request containing the parking details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPost]
    [Authorize(Roles = "Owner,Admin")]
    public async Task<IActionResult> RegisterParking([FromBody] RegisterParkingRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new RegisterParkingCommand(
                request.Name,
                new Domain.ValueObjects.Address(request.Address.StreetName, request.Address.Number, request.Address.PostalCode),
                request.Capacity,
                request.PricePerHour),
            cancellationToken);

        if (!result.IsSuccess)
            return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Deletes a parking based on the provided parkingId.
    /// </summary>
    /// <param name="parkingId">The id of the parking to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete]
    [Authorize(Roles = "Owner,Admin")]
    [Route("{parkingId}")]
    public async Task<IActionResult> DeleteParkingAsync([FromRoute] Guid parkingId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteParkingCommand(parkingId), cancellationToken);

        if (!result.IsSuccess)
            return NotFound(result.Message);
        return Ok(result.Data);
    }

    /// <summary>
    /// Updates a parking based on the provided parkingId and parking details.
    /// </summary>
    /// <param name="parkingId">The id of the parking to update.</param>
    /// <param name="parking">The updated parking details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut]
    [Authorize(Roles = "Owner,Admin")]
    [Route("{parkingId}")]
    public async Task<IActionResult> UpdateParking([FromRoute] Guid parkingId, [FromBody] UpdateParkingRequest parking, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new UpdateParkingCommand(
                parkingId,
                parking.Name,
                new Domain.ValueObjects.Address(parking.Address.StreetName, parking.Address.Number, parking.Address.PostalCode),
                parking.Capacity,
                parking.PricePerHour,
                parking.Status),
            cancellationToken);

        if (!result.IsSuccess)
            return NotFound(result.Message);
        return Ok(result.Data);
    }
}