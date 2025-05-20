using MediatR;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Queries;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;

namespace ParkBuddy.Application.Handlers.QueryHandlers
{
    public class GetParkingHandler : IRequestHandler<GetParkingQuery, Result<ParkingDto>>
    {
        private readonly IParkingRepository parkingRepository;

        public GetParkingHandler(IParkingRepository parking)
        {
            this.parkingRepository = parking;
        }

        public async Task<Result<ParkingDto>> Handle(GetParkingQuery request, CancellationToken cancellationToken)
        {
            var result = await parkingRepository.GetParkingAsync(request.ParkingId);

            if (result.IsSuccess)
                return Result<ParkingDto>.Success(result.Data, result.Message);
            return Result<ParkingDto>.Failure(result.Message);
        }
    }
}
