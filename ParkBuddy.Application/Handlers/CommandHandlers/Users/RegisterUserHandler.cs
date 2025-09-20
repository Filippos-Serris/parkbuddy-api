using MediatR;
using Microsoft.AspNetCore.Identity;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Contracts;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Application.Handlers.CommandHandlers.Users
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<Guid>>
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = request.userDto.Email,
                Email = request.userDto.Email,
                FirstName = request.userDto.FirstName,
                LastName = request.userDto.LastName
            };

            var result = await _userManager.CreateAsync(user, request.userDto.Password);

            if (result.Succeeded)
            {
                var role = request.userDto.Role.ToString();

                var roleResult = await _userManager.AddToRoleAsync(user, request.userDto.Role.ToString());
                if (roleResult.Succeeded)
                    return Result<Guid>.Success(user.Id, "Successful registration");
                else
                    return Result<Guid>.Failure("Registration succeeded, but failed to assign");
            }
            return Result<Guid>.Failure("Registeaton failed");
        }
    }
}
