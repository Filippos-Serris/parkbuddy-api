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
    /// <param name="command">The registration details for the new user.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for cancellation requests.</param>
    /// <returns>A result indicating success or failure of the registration operation.</returns>
    public async Task<Result<Guid>> RegisterUserAsync(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            UserName = command.Email,
        };

        var result = await _userManager.CreateAsync(newUser, command.Password);

        if (!result.Succeeded)
        {
            await transaction.RollbackAsync();
            return Result<Guid>.Failure("User creation failed", result.Errors.Select(e => e.Description).ToList());
        }

        var roleResult = await _userManager.AddToRoleAsync(newUser, command.Role.ToString());
        if (!roleResult.Succeeded)
        {
            await transaction.RollbackAsync();
            return Result<Guid>.Failure("Role assignment failed", roleResult.Errors.Select(e => e.Description).ToList());
        }

        await transaction.CommitAsync();
        return Result<Guid>.Success(newUser.Id, "Successful registration");
    }

    /// <summary>
    /// Updates an existing user's details based on the provided update command.
    /// </summary>
    /// <param name="command">The command containing updated user details.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for cancellation requests.</param>
    /// <returns>A result indicating success or failure of the update operation.</returns>
    public async Task<Result<bool>> UpdateUserAsync(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(command.UserId.ToString());

        if (user == null)
            return Result<bool>.Failure("User not found");

        if (!string.IsNullOrEmpty(command.FirstName))
            user.FirstName = command.FirstName;

        if (!string.IsNullOrEmpty(command.LastName))
            user.LastName = command.LastName;

        if (!string.IsNullOrEmpty(command.Email))
        {
            user.Email = command.Email;
            user.UserName = command.Email;
        }

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return Result<bool>.Failure("User update failed", result.Errors.Select(e => e.Description).ToList());
        }

        return Result<bool>.Success(true, "User updated successfully");
    }
}
