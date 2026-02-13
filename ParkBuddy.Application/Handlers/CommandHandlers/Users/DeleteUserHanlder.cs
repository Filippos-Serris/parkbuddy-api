using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers.Users
{
    public class DeleteUserHanlder : IRequestHandler<DeleteUserCommand, Result<bool>>
    {
        private readonly IUserAccountService _userAccountService;

        public DeleteUserHanlder(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userAccountService.DeleteUserAsync(request, cancellationToken);

            if (!result.IsSuccess)
                return Result<bool>.Failure(result.Message, result.Errors);
            return Result<bool>.Success(result.Data, result.Message);
        }
    }
}