using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Contracts.Dtos.Users
{
    public record RegisterUserDto(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        Roles Role);
}
