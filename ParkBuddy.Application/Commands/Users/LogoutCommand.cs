using MediatR;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Commands.Users
{
    /// <summary>
    /// Command for logging out a user.
    /// </summary>
    public record LogoutCommand() : IRequest<Result<bool>>;
}