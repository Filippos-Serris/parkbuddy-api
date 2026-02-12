using MediatR;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Commands.Users
{
    /// <summary>
    /// Represents a command to update user details.
    /// </summary>
    /// <param name="UserId">The unique identifier of the user to update.</param>
    /// <param name="FirstName">The first name of the user.</param>
    /// <param name="LastName">The last name of the user.</param>
    /// <param name="Email">The email address of the user.</param>
    public record UpdateUserCommand(
        Guid UserId,
        string? FirstName,
        string? LastName,
        string? Email) : IRequest<Result<bool>>;
}