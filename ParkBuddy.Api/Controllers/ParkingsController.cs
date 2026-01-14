using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Api.Dtos.Parking;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Queries.Parkings;

namespace ParkBuddy.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/")]
    public class ParkingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get list of availabe parkings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetParkings()
        {
            var result = await _mediator.Send(new GetParkingListQuery());

            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Get a spesific parking by providing a parkingId
        /// </summary>
        /// <param name="parkingId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Customer,Admin")]
        [Route("{parkingId}")]
        public async Task<IActionResult> GetParking(Guid parkingId)
        {
            var result = await _mediator.Send(new GetParkingQuery(parkingId));

            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
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
}