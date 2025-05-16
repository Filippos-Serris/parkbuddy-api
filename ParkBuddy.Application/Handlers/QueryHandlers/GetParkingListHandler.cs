using MediatR;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Queries;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;

namespace ParkBuddy.Application.Handlers.QueryHandlers
{
    public class GetParkingListHandler : IRequestHandler<GetParkingListQuery, Result<List<ParkingDto>>>
    {
        private readonly IParkingRepository parkingRepository;

        public GetParkingListHandler(IParkingRepository parking)
        {
            this.parkingRepository = parking;
        }

        public async Task<Result<List<ParkingDto>>> Handle(GetParkingListQuery request, CancellationToken cancellationToken)
        {
            var result = await parkingRepository.GetParkingListAsync();

            if (result.IsSuccess)
                return Result<List<ParkingDto>>.Success(result.Data, result.Message);
            return Result<List<ParkingDto>>.Failure(result.Message);
        }
    }
}