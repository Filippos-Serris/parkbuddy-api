using MediatR;
using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Common;
using ParkBuddy.Application.Dtos;
using ParkBuddy.Application.Queries;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Domain.Repositories;
using ParkBuddy.Infrastructure.Data;

namespace ParkBuddy.Application.Handlers.QueryHandlers
{
    public class GetParkingListHandler : IRequestHandler<GetParkingListQuery, Result<List<ParkingDto>>>
    {
        private readonly IParkingRepository parking;

        public GetParkingListHandler(IParkingRepository parking)
        {
            this.parking = parking;
        }

        public async Task<Result<List<ParkingDto>>> Handle(GetParkingListQuery request, CancellationToken cancellationToken)
        {
            var result = await parking.GetParkingListAsync();
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
    }
}