using MediatR;
using ParkBuddy.Application.Dtos;
using ParkBuddy.Application.Queries;
using ParkBuddy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBuddy.Application.Handlers.QueryHandlers
{
    public class GetParkingHandler : IRequestHandler<GetParkingQuery, ParkingDto>
    {
        private ParkBuddyContext context;

        public GetParkingHandler(ParkBuddyContext context)
        {
            this.context = context;
        }

        public async Task<ParkingDto> Handle(GetParkingQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Parkings.FindAsync(request.ParkingId);
            var parking = new ParkingDto
            {
                ParkingId = result.ParkingId,
                Name=result.Name,
                Address=result.Address,
                Capacity=result.Capacity,
                PricePerHour=result.PricePerHour,
                Status=result.Status.ToString(),
            };

            return parking;
        }
    }
}
