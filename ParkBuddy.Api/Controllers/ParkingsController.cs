using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Api.Dtos.Parking;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Interfaces;

namespace ParkBuddy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ParkingsController : ControllerBase
    {
        private readonly IParkingMediatorService mediator;

        public ParkingsController(IParkingMediatorService mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetParkings()
        {
            var result = await mediator.GetParkings();

            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("{parkingId}")]
        public async Task<IActionResult> GetParking(Guid parkingId)
        {
            var result = await mediator.GetParking(parkingId);

            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterParking(RegisterParkingRequest request)
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
        [Route("{parkingId}")]
        public async Task<IActionResult> DeleteParkingAsync(Guid parkingId)
        {
            var result = await mediator.DeleteParking(parkingId);

            if (!result.IsSuccess)
                return NotFound(result.Message);
            return Ok(result.Data);
        }

        [HttpPut]
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