using Microsoft.AspNetCore.Identity;
using ParkBuddy.Application.Commands.Users;
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

        public async Task<Result<LoginResponseCommand>> LoginAsync(LoginCommand command)
        {
            var user = await userManager.FindByEmailAsync(command.Email);
            if (user == null)
            {
                return Result<LoginResponseCommand>.Failure("No user found with this email");
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, command.Password, false);
            if (!result.Succeeded)
            {
                return Result<LoginResponseCommand>.Failure("Invalid password");
            }

            var role = (await userManager.GetRolesAsync(user)).FirstOrDefault();
            if (!Enum.TryParse<Roles>(role, true, out var roleEnum))
                throw new InvalidOperationException($"Role '{role}' is not defined in Roles enum.");

            var token = "sample_token";//await _tokenService.GenerateTokenAsync(user, roles);

            return Result<LoginResponseCommand>.Success(new LoginResponseCommand(
                user.Id, roleEnum, token, DateTime.UtcNow), "User loged in");
        }
    }
}
