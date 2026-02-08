using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Application.Dtos.User;

/// <summary>
/// Represents a data transfer object (DTO) for user login information.
/// </summary>
/// <param name="Id">The unique identifier of the user.</param>
/// <param name="Role">The role of the user.</param>
public record LoginDto(Guid Id, Roles Role)
{
}