using MediatR;
using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Queries;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;

namespace ParkBuddy.Application.Handlers.QueryHandlers
{
    public class GetParkingListHandler : IRequestHandler<GetParkingListQuery, List<Parking>>
    {
        private readonly ParkBuddyContext context;

        public GetParkingListHandler(ParkBuddyContext context)
        {
            this.context = context;
        }

        public async Task<List<Parking>> Handle(GetParkingListQuery request, CancellationToken cancellationToken)
        {
            var parkings = await context.Parkings.ToListAsync();
            return parkings;
        }
    }
}