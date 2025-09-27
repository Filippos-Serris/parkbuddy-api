using MediatR;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers
{
    public class DeleteParkingHandler : IRequestHandler<DeleteParkingCommand, Result<bool>>
    {
        private readonly IParkingRepository parking;

        public DeleteParkingHandler(IParkingRepository parking)
        {
            this.parking = parking;
        }

        public async Task<Result<bool>> Handle(DeleteParkingCommand request, CancellationToken cancellationToken)
        {
            var result = await parking.DeleteParkingAsync(request.ParkingId);

            if (!result.IsSuccess)
                return Result<bool>.Failure(result.Message);
            return Result<bool>.Success(result.Data, result.Message);
        }
    }
}
