using MediatR;
using ParkBuddy.Application.Commands;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;

namespace ParkBuddy.Application.Handlers.CommandHandlers
{
    public class RegisterParkingHandler : IRequestHandler<RegisterParkingCommand, Unit>
    {
        private readonly ParkBuddyContext context;

        public RegisterParkingHandler(ParkBuddyContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(RegisterParkingCommand request, CancellationToken cancellationToken)
        {
            var parking = new Parking
            {
                ParkingId = Guid.NewGuid(),
                Name = request.ParkingDto.Name,
                Address = request.ParkingDto.Address,
                Capacity = request.ParkingDto.Capacity,
                PricePerHour = request.ParkingDto.PricePerHour
            };

            context.Parkings.Add(parking);
            var result = await context.SaveChangesAsync() > 0;

            if (!result)
                throw new Exception("Failed to register parking");
            return Unit.Value;
        }
    }
}
