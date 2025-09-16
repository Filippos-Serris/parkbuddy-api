using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Dtos.Users;

namespace ParkBuddy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserMediatorService mediator;

        public UsersController(IUserMediatorService mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserDto user)
        {
            var result = await mediator.RegisterUser(user);
            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return NotFound();
        }


        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            return NotFound();
        }

        [HttpPatch]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId)
        {
            return NotFound();
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            return NotFound();
        }
    }
}
