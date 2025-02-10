using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Application.Dtos;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Validation;

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

            if (result == null)
                NotFound();

            return Ok(result);
        }

        [HttpGet("{parkingId}")]
        public async Task<IActionResult> GetParking(Guid parkingId)
        {
            var result = await parkingRepository.GetParkingAsync(parkingId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterParking(RegisterParkingDto parking)
        {
            var validator = new RegisterParkingDtoValidator();
            var validationResult = await validator.ValidateAsync(parking);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var result = await parkingRepository.RegisterParkingAsync(parking);

            if (result == null)
                return StatusCode(500, "Failed to register parking");

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParkingAsync(Guid parkingId)
        {
            var result = await parkingRepository.DeleteParkingAsync(parkingId);

            if (result)
                return Ok();
            else
                return NotFound();
        }
    }
}