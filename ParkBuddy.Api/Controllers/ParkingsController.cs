using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ParkBuddy.Application.Dtos;
using ParkBuddy.Application.Interfaces;
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
            var result = await parkingRepository.RegisterParkingAsync(parking);

            if (result == null)
                return BadRequest();

            return Ok();
        }
    }
}