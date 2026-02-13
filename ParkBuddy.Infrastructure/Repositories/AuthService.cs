using Microsoft.AspNetCore.Identity;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Dtos.User;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Infrastructure.Repositories;

/// <summary>
/// Service responsible for handling authentication-related operations.
/// </summary>
public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthService"/> class.
    /// </summary>
    /// <param name="userManager">UserManager.</param>
    /// <param name="signInManager">SignInManager.</param>
    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    /// <summary>
    /// Authenticates a user based on the provided email and password, and returns a JWT token if successful.
    /// </summary>
    /// <param name="command">Log in information.</param>
    /// <param name="cancellationToken">CancellationToken.</param>
    /// <returns>Result of the login operation.</returns>
    public async Task<Result<LoginDto>> LoginAsync(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(command.Email);
        if (user == null)
        {
            return Result<LoginDto>.Failure("No user found with this email");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, command.Password, false);
        if (!result.Succeeded)
        {
            return Result<LoginDto>.Failure("Invalid password");
        }

        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
        if (!Enum.TryParse<Roles>(role, true, out var roleEnum))
        {
            throw new InvalidOperationException($"Role '{role}' is not defined in Roles enum.");
        }

        return Result<LoginDto>.Success(new LoginDto(user.Id, roleEnum), "User logged in successfully");
    }

    /// <summary>
    /// Logs out the currently authenticated user.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    public async Task<Result<bool>> LogoutAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _signInManager.SignOutAsync();
            return Result<bool>.Success(true, "User logged out successfully");
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure("An error occurred while logging out", new List<string> { ex.Message });
        }
    }
}
