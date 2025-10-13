using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Application.Dtos.User
{
    public record LoginDto(Guid Id, Roles Role)
    {
    }
}