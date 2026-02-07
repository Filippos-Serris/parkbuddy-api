using Microsoft.AspNetCore.Identity;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Dtos.User;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthRepository(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

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
            throw new InvalidOperationException($"Role '{role}' is not defined in Roles enum.");

        return Result<LoginDto>.Success(new LoginDto(
            user.Id, roleEnum), "User loged in");
    }
}
