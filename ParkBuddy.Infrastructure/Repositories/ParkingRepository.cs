using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;

namespace ParkBuddy.Infrastructure.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ParkBuddyContext context;

        public ParkingRepository(ParkBuddyContext context)
        {
            this.context = context;
        }

        public async Task<Result<ParkingListDto>> GetParkingListAsync()
        {
            var parkings = await context.Parkings
                .Select(p => new ParkingDto(
                    p.ParkingId,
                    p.Name,
                    p.Address,
                    p.Capacity,
                    p.PricePerHour,
                    p.Status
                )).ToListAsync();

            var result = new ParkingListDto(parkings);

            if (result == null)
                return Result<ParkingListDto>.Failure("Parkings not retrieved.");
            return Result<ParkingListDto>.Success(result, "Parkings retrieved succeffully");
        }

        public async Task<Result<ParkingDto>> GetParkingAsync(Guid ParkingId)
        {
            var result = await context.Parkings
                .Where(p => p.ParkingId == ParkingId)
                .Select(p => new ParkingDto(
                    p.ParkingId,
                    p.Name,
                    p.Address,
                    p.Capacity,
                    p.PricePerHour,
                    p.Status)
                )
                .FirstOrDefaultAsync();

            if (result == null)
                return Result<ParkingDto>.Failure("Parking not retrieved.");
            return Result<ParkingDto>.Success(result, "Parking retrieved succeffully");
        }

        public async Task<Result<Guid>> RegisterParkingAsync(RegisterParkingCommand command)
        {

            var newParking = new Parking
            {
                ParkingId = Guid.NewGuid(),
                Name = command.Name,
                Address = command.Address.ToString(),
                Capacity = command.Capacity,
                PricePerHour = command.PricePerHour
            };

            context.Add(newParking);
            var result = await context.SaveChangesAsync() > 0;

            if (result)
                return Result<Guid>.Success(newParking.ParkingId, "Parkign registered successfully");
            return Result<Guid>.Failure("Failed to register command");
        }

        public async Task<Result<bool>> DeleteParkingAsync(Guid parkingId)
        {
            var result = await context.Parkings.Where(p => p.ParkingId == parkingId).ExecuteDeleteAsync() > 0;

            if (result)
                return Result<bool>.Success(true, "Parking deleted successfully");
            return Result<bool>.Failure("Failed to delete p");
        }

        public async Task<Result<ParkingDto>> UpdateParkingAsync(UpdateParkingCommand newParking)
        {
            var parking = await context.Parkings.FindAsync(newParking.Id);

            if (parking == null)
                return Result<ParkingDto>.Failure("Parking not found, failed to delete.");

            parking.Name = newParking.Name;
            parking.Address = newParking.Address.ToString();
            parking.Capacity = newParking.Capacity;
            parking.PricePerHour = newParking.PricePerHour;
            parking.Status = newParking.Status;

            var result = await context.SaveChangesAsync() > 0;

            if (result)
            {
                return Result<ParkingDto>.Success(new ParkingDto(
                    parking.ParkingId,
                    parking.Name,
                    parking.Address,
                    parking.Capacity,
                    parking.PricePerHour,
                    parking.Status)
                    , "Parking updated successfully");
            }
            return Result<ParkingDto>.Failure("Failed to update parking");
        }
    }
}
