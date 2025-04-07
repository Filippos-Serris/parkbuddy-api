using MediatR;
using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Queries;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;

namespace ParkBuddy.Application.Handlers.QueryHandlers
{
    public class ParkingListHandler : IRequestHandler<ParkingListQuery, List<Parking>>
    {
        private readonly ParkBuddyContext context;

        public ParkingListHandler(ParkBuddyContext context)
        {
            this.context = context;
        }

        public async Task<List<Parking>> Handle(ParkingListQuery request, CancellationToken cancellationToken)
        {
            var parkings = await context.Parkings.ToListAsync();
            return parkings;
        }
    }
}