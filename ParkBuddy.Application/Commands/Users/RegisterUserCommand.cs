using MediatR;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Application.Commands.Users;

/// <summary>
/// Represents a command to register a new user with the specified details.
/// </summary>
/// <param name="FirstName">The first name of the user.</param>
/// <param name="LastName">The last name of the user.</param>
/// <param name="Email">The email of the user.</param>
/// <param name="Password">The password of the user.</param>
/// <param name="Role">The role of the user.</param>
public record RegisterUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    Roles Role) : IRequest<Result<Guid>>;
