using MediatR;
using ParkBuddy.Application.Commands;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts;

namespace ParkBuddy.Application.Handlers.CommandHandlers
{
    public class RegisterParkingHandler : IRequestHandler<RegisterParkingCommand, Result<Guid>>
    {
        private readonly IParkingRepository parkingRepository;

        public RegisterParkingHandler(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        public async Task<Result<Guid>> Handle(RegisterParkingCommand request, CancellationToken cancellationToken)
        {
            var result = await parkingRepository.RegisterParkingAsync(request.ParkingDto);

            if (!result.IsSuccess)
                return Result<Guid>.Failure(result.Message);
            return Result<Guid>.Success(result.Data, result.Message);
        }
    }
}
