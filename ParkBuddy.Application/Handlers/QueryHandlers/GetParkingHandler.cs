using MediatR;
using ParkBuddy.Application.Queries;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;
using ParkBuddy.Domain.Repositories;

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
            {
                var parking = new ParkingDto
                {
                    ParkingId = result.Data.ParkingId,
                    Name = result.Data.Name,
                    Address = result.Data.Address,
                    Capacity = result.Data.Capacity,
                    PricePerHour = result.Data.PricePerHour,
                    Status = result.Data.Status.ToString(),
                };
                return Result<ParkingDto>.Success(parking, result.Message);
            }
            return Result<ParkingDto>.Failure(result.Message);
        }
    }
}
