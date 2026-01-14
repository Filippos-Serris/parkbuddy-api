using MediatR;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers
{
    public class UpdateParkingHandler : IRequestHandler<UpdateParkingCommand, Result<ParkingDto>>
    {
        private readonly IParkingRepository _repository;

        public UpdateParkingHandler(IParkingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ParkingDto>> Handle(UpdateParkingCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.UpdateParkingAsync(request);

            if (!result.IsSuccess)
                return Result<ParkingDto>.Failure(result.Message);
            return Result<ParkingDto>.Success(result.Data, result.Message);
        }
    }
}
