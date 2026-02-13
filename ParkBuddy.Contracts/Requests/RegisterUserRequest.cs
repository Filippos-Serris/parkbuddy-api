using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Contracts.Requests;

public record RegisterUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    Roles Role);
