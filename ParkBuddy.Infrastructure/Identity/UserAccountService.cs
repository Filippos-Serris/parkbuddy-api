using Microsoft.AspNetCore.Identity;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;

namespace ParkBuddy.Infrastructure.Identity;

/// <summary>
/// Repository for managing user-related operations. 
/// </summary>
public class UserAccountService : IUserAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly ParkBuddyContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserAccountService"/> class with the specified database context and user manager.
    /// </summary>
    /// <param name="context">The database context to be used by the repository.</param>
    /// <param name="userManager">The user manager to be used by the repository.</param>
    public UserAccountService(ParkBuddyContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    /// <summary>
    /// Registers a new user with the provided registration details.
    /// </summary>
    /// <param name="user">The registration details for the new user.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for cancellation requests.</param>
    /// <returns>A result indicating success or failure of the registration operation.</returns>
    public async Task<Result<Guid>> RegisterUserAsync(RegisterUserCommand user, CancellationToken cancellationToken)
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
            return Result<Guid>.Failure("User creation failed", result.Errors.Select(e => e.Description).ToList());
        }

        var roleResult = await _userManager.AddToRoleAsync(newUser, user.Role.ToString());
        if (!roleResult.Succeeded)
        {
            await transaction.RollbackAsync();
            return Result<Guid>.Failure("Role assignment failed", roleResult.Errors.Select(e => e.Description).ToList());
        }

        await transaction.CommitAsync();
        return Result<Guid>.Success(newUser.Id, "Successful registration");
    }
}
