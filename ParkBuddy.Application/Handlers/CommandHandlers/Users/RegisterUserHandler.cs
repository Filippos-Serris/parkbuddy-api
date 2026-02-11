using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers.Users;

/// <summary>
/// Represents a handler for the RegisterUserCommand..
/// </summary>
public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<Guid>>
{
    private readonly IUserAccountService _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterUserHandler"/> class.
    /// </summary>
    /// <param name="repository">The user repository to use for handling the command.</param>
    public RegisterUserHandler(IUserAccountService repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the RegisterUserCommand.
    /// </summary>
    /// <param name="request">The register user command to handle.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.RegisterUserAsync(request, cancellationToken);

        if (!result.IsSuccess)
            return Result<Guid>.Failure(result.Message, result.Errors);
        return Result<Guid>.Success(result.Data, result.Message);
    }
}
