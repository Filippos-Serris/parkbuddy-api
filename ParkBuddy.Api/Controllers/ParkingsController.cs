using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Api.Dtos.Parking;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Queries.Parkings;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Contracts.Responses;

namespace ParkBuddy.Api.Controllers;

[ApiController]
//[Authorize]
[Route("api/[controller]/")]
public class ParkingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParkingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get list of available parkings
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    //[Authorize(Roles = "Customer,Admin")]
    public async Task<IActionResult> GetParkings()
    {
        var data = await _mediator.Send(new GetParkingListQuery());

        if (!data.IsSuccess)
            return NotFound();

        var response = new GetParkingListResponse(
            Result<List<ParkingListItem>>.Success(
                data.Data.Select(p => new ParkingListItem(
                    p.Id,
                    p.Name,
                    $"{p.Address.StreetName} {p.Address.Number}, {p.Address.PostalCode}",
                    p.PricePerHour,
                    p.Status.ToString()
                )).ToList(),
                data.Message
            )
        );

        return Ok(response);
    }

    /// <summary>
    /// Get a specific parking by providing a parkingId
    /// </summary>
    /// <param name="parkingId"></param>
    /// <returns></returns>
    [HttpGet]
    //[Authorize(Roles = "Customer,Admin")]
    [Route("{parkingId}")]
    public async Task<IActionResult> GetParking(Guid parkingId)
    {
        var data = await _mediator.Send(new GetParkingQuery(parkingId));

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
            data.Message
        );

        return Ok(response);
    }

    [HttpPost]
    [Authorize(Roles = "Owner,Admin")]
    public async Task<IActionResult> RegisterParking([FromBody] RegisterParkingRequest request)
    {
        var result = await _mediator.Send(
            new RegisterParkingCommand(
                request.Name,
                new Domain.ValueObjects.Address(request.Address.StreetName, request.Address.Number, request.Address.PostalCode),
                request.Capacity,
                request.PricePerHour));

        if (!result.IsSuccess)
            return NotFound();
        return Ok(result);
    }

    [HttpDelete]
    [Authorize(Roles = "Owner,Admin")]
    [Route("{parkingId}")]
    public async Task<IActionResult> DeleteParkingAsync(Guid parkingId)
    {
        var result = await _mediator.Send(new DeleteParkingCommand(parkingId));

        if (!result.IsSuccess)
            return NotFound(result.Message);
        return Ok(result.Data);
    }

    [HttpPut]
    [Authorize(Roles = "Owner,Admin")]
    [Route("{parkingId}")]
    public async Task<IActionResult> UpdateParking(Guid parkingId, UpadateParkingRequest parking)
    {
        var result = await _mediator.Send(new UpdateParkingCommand(
            parkingId,
            parking.Name,
            new Domain.ValueObjects.Address(parking.Address.StreetName, parking.Address.Number, parking.Address.PostalCode),
            parking.Capacity,
            parking.PricePerHour,
            parking.Status));

        if (!result.IsSuccess)
            return NotFound(result.Message);
        return Ok(result.Data);
    }
}