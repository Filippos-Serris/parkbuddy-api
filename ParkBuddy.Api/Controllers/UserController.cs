using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
            return BadRequest(result);
        return Ok(result);
    }

    /// <summary>
    /// Updates user's details.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to update.</param>
    /// <param name="request">The request containing updated user details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPatch("{userId}")]
    [Authorize]
    public async Task<IActionResult> UpdateUser(
        [FromRoute] string userId,
        [FromBody] UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        var claimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (claimUserId != userId)
            return Unauthorized();

        var result = await _mediator.Send(
            new UpdateUserCommand(
                new Guid(userId),
                request.FirstName,
                request.LastName,
                request.Email),
            cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }

    /// <summary>
    /// Updates the password of a user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose password is to be updated.</param>
    /// <param name="request">The request containing the current and new password details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPatch("{userId}/password")]
    [Authorize]
    public async Task<IActionResult> UpdateUserPassword(
        [FromRoute] string userId,
        [FromBody] UpdateUserPasswordRequest request,
        CancellationToken cancellationToken)
    {
        var claimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (claimUserId != userId)
            return Unauthorized();

        var result = await _mediator.Send(
            new UpdateUserPasswordCommand(
                new Guid(userId),
                request.CurrentPassword,
                request.NewPassword),
            cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }
}
