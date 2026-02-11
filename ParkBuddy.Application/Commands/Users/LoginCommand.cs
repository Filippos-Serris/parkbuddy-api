using MediatR;
using ParkBuddy.Application.Results;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Commands.Users;

/// <summary>
/// Represents a command to log in a user with the specified email and password.
/// </summary>
/// <param name="Email">Users email.</param>
/// <param name="Password">Users password.</param>
public record LoginCommand(string Email, string Password) : IRequest<Result<LoginResult>>
{
}
