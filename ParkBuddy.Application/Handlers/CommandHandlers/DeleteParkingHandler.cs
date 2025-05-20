using MediatR;
using ParkBuddy.Application.Commands;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts;

namespace ParkBuddy.Application.Handlers.CommandHandlers
{
    public class DeleteParkingHandler : IRequestHandler<DeleteParkingCommand, Result<string>>
    {
        private readonly IParkingRepository parking;

        public DeleteParkingHandler(IParkingRepository parking)
        {
            this.parking = parking;
        }

        public async Task<Result<string>> Handle(DeleteParkingCommand request, CancellationToken cancellationToken)
        {
            var result = await parking.DeleteParkingAsync(request.ParkingId);

            if (!result.IsSuccess)
                return Result<string>.Failure(result.Message);
            return Result<string>.Success(result.Data, result.Message);
        }
    }
}
