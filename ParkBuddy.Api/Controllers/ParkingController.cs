using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Application.Dtos;
using ParkBuddy.Application.Interfaces;

namespace ParkBuddy.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingRepository parkingRepository;
        public ParkingController(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingDto>>> GetParkings()
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
    }
}