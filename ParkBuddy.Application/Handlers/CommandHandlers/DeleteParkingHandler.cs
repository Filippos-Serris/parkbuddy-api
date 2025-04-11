using MediatR;
using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Commands;
using ParkBuddy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBuddy.Application.Handlers.CommandHandlers
{
    public class DeleteParkingHandler : IRequestHandler<DeleteParkingCommand, Unit>
    {
        private readonly ParkBuddyContext context;

        public DeleteParkingHandler(ParkBuddyContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteParkingCommand request, CancellationToken cancellationToken)
        {
            var result = await context.Parkings.Where(p => p.ParkingId == request.ParkingId).ExecuteDeleteAsync();
            return Unit.Value;
        }
    }
}
