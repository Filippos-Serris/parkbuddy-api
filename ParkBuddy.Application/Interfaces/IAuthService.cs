using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Dtos.User;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Interfaces;

/// <summary>
/// Interface for authentication service, providing methods for user login and logout operations.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Logs in a user based on the provided login command.
    /// </summary>
    /// <param name="command">The login command containing user credentials.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task<Result<LoginDto>> LoginAsync(LoginCommand command, CancellationToken cancellationToken);

    /// <summary>
    /// Logs out the currently authenticated user.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task<Result<bool>> LogoutAsync(CancellationToken cancellationToken);
}
