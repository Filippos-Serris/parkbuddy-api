using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Contracts.Requests;

namespace ParkBuddy.Api.Controllers;

/// <summary>
/// Controller responsible for handling user-related operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="mediator">Mediator.</param>
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Registers a new user based on the provided user details in the request body.
    /// </summary>
    /// <param name="user">The user details to register.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A <see cref="Task"/> An HTTP response indicating the result of the registration operation.</returns>
    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest user, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new RegisterUserCommand(
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                user.Role),
            cancellationToken);

        if (!result.IsSuccess)
            return NotFound();
        return Created();
    }
}
