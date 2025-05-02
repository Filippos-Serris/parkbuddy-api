using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Application;
using ParkBuddy.Application.Commands;
using ParkBuddy.Application.Dtos;
using ParkBuddy.Application.Queries;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ParkingsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ParkingsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetParkings()
        {
            var result = await mediator.Send(new GetParkingListQuery());

            if(!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("parking")]
        public async Task<IActionResult> GetParking(Guid parkingId)
        {
            var result = await mediator.Send(new GetParkingQuery(parkingId));
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterParking(RegisterParkingDto parking)
        {
            var result = await mediator.Send(new RegisterParkingCommand(parking));
            return Ok(new ApiResponse<object>(true, "Parking registeed successfully"));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParkingAsync(Guid parkingId)
        {
            var result = await mediator.Send(new DeleteParkingCommand(parkingId));

            if (!result.IsSuccess)
                return NotFound(result.Message);
            return Ok(result.Data);
        }
    }
}