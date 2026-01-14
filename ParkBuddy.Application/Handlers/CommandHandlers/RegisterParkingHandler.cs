using MediatR;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers
{
    public class RegisterParkingHandler : IRequestHandler<RegisterParkingCommand, Result<Guid>>
    {
        private readonly IParkingRepository _repository;

        public RegisterParkingHandler(IParkingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(RegisterParkingCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.RegisterParkingAsync(request);

            if (!result.IsSuccess)
                return Result<Guid>.Failure(result.Message);
            return Result<Guid>.Success(result.Data, result.Message);
        }
    }
}
