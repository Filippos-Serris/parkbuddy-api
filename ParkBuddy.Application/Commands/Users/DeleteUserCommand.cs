using MediatR;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Commands.Users
{
    /// <summary>
    /// Command for deleting a user account.
    /// </summary>
    public record DeleteUserCommand(Guid UserId) : IRequest<Result<bool>>;
}