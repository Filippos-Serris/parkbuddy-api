using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Api.Dtos.Parking;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Interfaces;

namespace ParkBuddy.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]/")]
    public class ParkingsController : ControllerBase
    {
        private readonly IParkingMediatorService mediator;

        public ParkingsController(IParkingMediatorService mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get list of availabe parkings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetParkings()
        {
            var result = await mediator.GetParkings();

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
        //[Authorize(Roles = "Customer,Admin")]
        [Route("{parkingId}")]
        public async Task<IActionResult> GetParking(Guid parkingId)
        {
            var result = await mediator.GetParking(parkingId);

            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        //[Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> RegisterParking([FromBody] RegisterParkingRequest request)
        {
            var result = await mediator.RegisterParking(
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
            var result = await mediator.DeleteParking(parkingId);

            if (!result.IsSuccess)
                return NotFound(result.Message);
            return Ok(result.Data);
        }

        [HttpPut]
        //[Authorize(Roles = "Owner,Admin")]
        [Route("{parkingId}")]
        public async Task<IActionResult> UpdateParking(Guid parkingId, UpadateParkingRequest parking)
        {
            var result = await mediator.UpdateParking(new UpdateParkingCommand(
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