using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Api.Dtos.User;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;

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
        public async Task<IActionResult> RegisterUser(RegisterUserRequestDto user)
        {
            var result = await mediator.RegisterUser(
                new RegisterUserCommand(
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.Password,
                    user.Role));

            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }
    }
}
