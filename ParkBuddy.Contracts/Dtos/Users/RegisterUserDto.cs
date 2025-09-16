namespace ParkBuddy.Contracts.Dtos.Users
{
    public record RegisterUserDto(
        string FirstName,
        string LastName,
        string Email,
        string Password);
}
