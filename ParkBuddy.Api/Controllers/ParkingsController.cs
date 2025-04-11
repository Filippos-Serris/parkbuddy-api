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
            var result = await mediator.Send(new ParkingListQuery());

            if (result == null || !result.Any())
                return Ok(new ApiResponse<object>(true, "No parkings available", new List<Parking>()));

            return Ok(new ApiResponse<List<Parking>>(true, "Parkings retrieved successfully", result));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterParking(RegisterParkingDto parking)
        {
            var result = await mediator.Send(new RegisterParkingCommand(parking));
            return Ok(new ApiResponse<object>(true, "Parking registeed successfully"));
        }

        /* [HttpGet("{parkingId}")]
        public async Task<IActionResult> GetParking(Guid parkingId)
        {
            var result = //TODO

            if (result == null)
                return NotFound(new ApiResponse<object>(false, "Parking not found"));

            return Ok(new ApiResponse<Parking>(true, "Parking retrieved successfully", result));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterParking(RegisterParkingDto parking)
        {
            var validator = new RegisterParkingDtoValidator();
            var validationResult = await validator.ValidateAsync(parking);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(new ApiResponse<object>(false, "Validation failed", errors));
            }

            var result = //TODO

            if (result == null)
                return StatusCode(500, new ApiResponse<object>(false, "Failed to register parking"));

            return Ok(new ApiResponse<Parking>(true, "Parking register successfully", result));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParkingAsync(Guid parkingId)
        {
            var result = //TODO

            if (!result)
                return NotFound(new ApiResponse<object>(false, "Parking not found"));

            return Ok(new ApiResponse<object>(true, "Parking deleted successfully"));
        }*/
    }
}