namespace ParkBuddy.Contracts.Requests
{
    /// <summary>
    /// Represents a request to update user details.
    /// </summary>
    /// <param name="FirstName">The first name of the user.</param>
    /// <param name="LastName">The last name of the user.</param>
    /// <param name="Email">The email address of the user.</param>
    public record UpdateUserRequest
    (
        string? FirstName,
        string? LastName,
        string? Email);
}