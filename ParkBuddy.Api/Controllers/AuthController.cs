using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Application.Commands.Users;

namespace ParkBuddy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Authenticates a user based on the provided email and password, and returns a JWT token if successful.
    /// </summary>
    /// <param name="request">The login request containing email and password.S</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _mediator.Send(new LoginCommand(request.Email, request.Password));

        if (result.IsSuccess)
            return Ok(result);
        return Unauthorized(result);
    }
}
