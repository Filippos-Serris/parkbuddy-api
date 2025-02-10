using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Application;
using ParkBuddy.Application.Dtos;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Validation;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ParkingsController : ControllerBase
    {
        private readonly IParkingRepository parkingRepository;
        public ParkingsController(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetParkings()
        {
            var result = await parkingRepository.GetParkingsAsync();

            if (result == null || !result.Any())
                return Ok(new ApiResponse<object>(true, "No parkings available", new List<Parking>()));

            return Ok(new ApiResponse<List<Parking>>(true, "Parkings retrieved successfully", result));
        }

        [HttpGet("{parkingId}")]
        public async Task<IActionResult> GetParking(Guid parkingId)
        {
            var result = await parkingRepository.GetParkingAsync(parkingId);

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

            var result = await parkingRepository.RegisterParkingAsync(parking);

            if (result == null)
                return StatusCode(500, new ApiResponse<object>(false, "Failed to register parking"));

            return Ok(new ApiResponse<Parking>(true, "Parking register successfully", result));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParkingAsync(Guid parkingId)
        {
            var result = await parkingRepository.DeleteParkingAsync(parkingId);

            if (!result)
                return NotFound(new ApiResponse<object>(false, "Parking not found"));

            return Ok(new ApiResponse<object>(true, "Parking deleted successfully"));
        }
    }
}