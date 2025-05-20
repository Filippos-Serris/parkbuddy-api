using MediatR;
using ParkBuddy.Application.Commands;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;

namespace ParkBuddy.Application.Handlers.CommandHandlers
{
    public class UpdateParkingHandler : IRequestHandler<UpdateParkingCommand, Result<ParkingDto>>
    {
        private readonly IParkingRepository repository;

        public UpdateParkingHandler(IParkingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<ParkingDto>> Handle(UpdateParkingCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.UpdateParkingAsync(request.ParkingDto);

            if (!result.IsSuccess)
                return Result<ParkingDto>.Failure(result.Message);
            return Result<ParkingDto>.Success(result.Data, result.Message);
        }
    }
}
