namespace ParkBuddy.Contracts.Requests
{
    /// <summary>
    /// Represents a request to update a user's password.
    /// </summary>
    /// <param name="CurrentPassword">The current password of the user.</param>
    /// <param name="NewPassword">The new password of the user.</param>
    public record UpdateUserPasswordRequest(
        string CurrentPassword,
        string NewPassword);
}