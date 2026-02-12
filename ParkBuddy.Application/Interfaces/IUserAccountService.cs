using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Interfaces;

/// <summary>
/// Interface for user account management services.
/// </summary>
public interface IUserAccountService
{
    /// <summary>
    /// Registers a new user with the provided registration details.
    /// </summary>
    /// <param name="command">The command containing user registration details.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task<Result<Guid>> RegisterUserAsync(RegisterUserCommand command, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing user's details based on the provided update command.
    /// </summary>
    /// <param name="command">The command containing user update details.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task<Result<bool>> UpdateUserAsync(UpdateUserCommand command, CancellationToken cancellationToken);
}
