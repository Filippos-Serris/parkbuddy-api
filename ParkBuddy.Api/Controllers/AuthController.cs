using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Application.Interfaces;

namespace ParkBuddy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthMediatorService mediator;

        public AuthController(IAuthMediatorService mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await mediator.Login(new Application.Commands.Users.LoginCommand(request.Email, request.Password));
            
            if(result.IsSuccess)
                return Ok(result);
            return Unauthorized(result);
        }
    }
}
