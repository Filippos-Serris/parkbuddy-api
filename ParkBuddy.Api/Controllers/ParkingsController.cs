using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Application.Commands;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Queries;
using ParkBuddy.Contracts.Dtos;

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
        [Route("parking")]
        public async Task<IActionResult> GetParking(Guid parkingId)
        {
            var result = await mediator.GetParking(parkingId);

            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterParking(RegisterParkingDto parking)
        {
            var result = await mediator.RegisterParking(parking);

            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParkingAsync(Guid parkingId)
        {
            var result = await mediator.DeleteParking(parkingId);

            if (!result.IsSuccess)
                return NotFound(result.Message);
            return Ok(result.Data);
        }
    }
}