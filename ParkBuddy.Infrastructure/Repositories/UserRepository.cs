using Microsoft.AspNetCore.Identity;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;

namespace ParkBuddy.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly ParkBuddyContext _context;

    public UserRepository(ParkBuddyContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<Result<Guid>> RegisterUserAsync(RegisterUserCommand user)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserName = user.Email,
        };

        var result = await _userManager.CreateAsync(newUser, user.Password);

        if (!result.Succeeded)
        {
            await transaction.RollbackAsync();
            return Result<Guid>.Failure("User creation failed");
        }

        var roleResult = await _userManager.AddToRoleAsync(newUser, user.Role.ToString());
        if (!roleResult.Succeeded)
        {
            await transaction.RollbackAsync();
            return Result<Guid>.Failure("Role assignment failed");
        }

        await transaction.CommitAsync();
        return Result<Guid>.Success(newUser.Id, "Successful registration");
    }
}
