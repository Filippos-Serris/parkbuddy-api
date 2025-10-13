using Microsoft.AspNetCore.Identity;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Dtos.User;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AuthRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<Result<LoginDto>> LoginAsync(LoginCommand command)
        {
            var user = await userManager.FindByEmailAsync(command.Email);
            if (user == null)
            {
                return Result<LoginDto>.Failure("No user found with this email");
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, command.Password, false);
            if (!result.Succeeded)
            {
                return Result<LoginDto>.Failure("Invalid password");
            }

            var role = (await userManager.GetRolesAsync(user)).FirstOrDefault();
            if (!Enum.TryParse<Roles>(role, true, out var roleEnum))
                throw new InvalidOperationException($"Role '{role}' is not defined in Roles enum.");

            return Result<LoginDto>.Success(new LoginDto(
                user.Id, roleEnum), "User loged in");
        }
    }
}
