using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Application.Results;

/// <summary>
/// Represents the result of a user login operation.
/// </summary>
/// <param name="Id">The unique identifier of the logged-in user.</param>
/// <param name="Role">The role of the logged-in user.</param>
/// <param name="Token">The authentication token for the logged-in user.</param>
public record LoginResult(
    Guid Id,
    Roles Role,
    string Token);