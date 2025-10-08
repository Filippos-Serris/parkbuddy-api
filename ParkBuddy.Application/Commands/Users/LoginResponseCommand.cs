using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Application.Commands.Users
{
    public record LoginResponseCommand(Guid Id, Roles Role, string Token, DateTime Expiration)
    {
    }
}
