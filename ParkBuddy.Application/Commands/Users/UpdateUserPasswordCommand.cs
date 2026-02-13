using MediatR;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Commands.Users
{
    /// <summary>
    /// Represents a command to update a user's password.
    /// </summary>
    /// <param name="UserId">The unique identifier of the user.</param>
    /// <param name="CurrentPassword">The current password of the user.</param>
    /// <param name="NewPassword">The new password of the user.</param>
    public record UpdateUserPasswordCommand(
        Guid UserId,
        string CurrentPassword,
        string NewPassword) : IRequest<Result<bool>>;
}