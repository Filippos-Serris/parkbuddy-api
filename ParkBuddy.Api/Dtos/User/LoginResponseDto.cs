using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Api.Dtos.User
{
    public record LoginResponseDto(Guid Id, Roles Role, string Token, DateTime Expiration)
    {
    }
}
