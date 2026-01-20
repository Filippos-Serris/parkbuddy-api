using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Contracts.Requests;

namespace ParkBuddy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(RegisterUserRequest user)
    {
        var result = await _mediator.Send(
            new RegisterUserCommand(
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                user.Role));

        if (!result.IsSuccess)
            return NotFound();
        return Created();
    }
}
