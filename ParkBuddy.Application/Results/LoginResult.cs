using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Application.Results
{
    public record LoginResult(
        Guid Id,
        Roles Role,
        string Token);
}