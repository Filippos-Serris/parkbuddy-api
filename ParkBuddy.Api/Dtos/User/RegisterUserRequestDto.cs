using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Api.Dtos.User
{
    public record RegisterUserRequestDto(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        Roles Role);
}
