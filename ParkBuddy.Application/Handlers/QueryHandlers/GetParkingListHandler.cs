using MediatR;
using ParkBuddy.Application.Queries;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Domain.Repositories;

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
            {
                var parkings = new List<ParkingDto>();

                foreach (var parking in result.Data)
                {
                    parkings.Add(new ParkingDto
                    {
                        ParkingId = parking.ParkingId,
                        Name = parking.Name,
                        Address = parking.Address,
                        Capacity = parking.Capacity,
                        PricePerHour = parking.PricePerHour,
                        Status = parking.Status.ToString(),
                    });
                }
                return Result<List<ParkingDto>>.Success(parkings, result.Message);
            }
            return Result<List<ParkingDto>>.Failure(result.Message);
        }
    }
}