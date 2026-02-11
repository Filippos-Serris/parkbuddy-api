using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Application.Commands.Users;

namespace ParkBuddy.Api.Controllers;

/// <summary>
/// Controller responsible for handling authentication-related operations, such as user login. It uses MediatR to send commands to the application layer and returns appropriate HTTP responses based on the results of those commands.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthController"/> class with the specified MediatR instance for handling commands and queries related to authentication.
    /// </summary>
    /// <param name="mediator">Mediator.</param>
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Authenticates a user based on the provided email and password, and returns a JWT token if successful.
    /// </summary>
    /// <param name="request">The login request containing email and password.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>An <see cref="IActionResult"/> Containing the login result.</returns>
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LoginCommand(request.Email, request.Password), cancellationToken);

        if (result.IsSuccess)
            return Ok(result);
        return Unauthorized(result);
    }
}
