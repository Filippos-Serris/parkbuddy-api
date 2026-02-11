using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Results;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers;

/// <summary>
/// Handler for processing the <see cref="LoginCommand"/>.
/// </summary>
public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResult>>
{
    private readonly IAuthRepository _repository;
    private readonly IJwtTokenService _tokenService;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginCommandHandler"/> class.
    /// </summary>
    /// <param name="repository">The authentication repository to use for handling the login command.</param>
    /// <param name="tokenService">The JWT token service to use for generating tokens.</param>
    public LoginCommandHandler(IAuthRepository repository, IJwtTokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<Result<LoginResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var login = await _repository.LoginAsync(request, cancellationToken);

        if (!login.IsSuccess)
            return Result<LoginResult>.Failure(login.Message);

        var token = _tokenService.GenerateToken(login.Data.Id, request.Email, login.Data.Role.ToString());

        var result = new LoginResult(login.Data.Id, login.Data.Role, token);

        return Result<LoginResult>.Success(result, login.Message);
    }
}
