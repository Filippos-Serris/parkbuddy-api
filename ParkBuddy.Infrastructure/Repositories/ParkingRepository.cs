using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Dtos;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Mappings;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;

namespace ParkBuddy.Infrastructure.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ParkBuddyContext parkBuddyContext;
        private readonly IParkingMapper parkingMapper;

        public ParkingRepository(ParkBuddyContext parkBuddyContext, IParkingMapper parkingMapper)
        {
            this.parkBuddyContext = parkBuddyContext;
            this.parkingMapper = parkingMapper;
        }
        public async Task<List<Parking>> GetParkingsAsync()
        {
            var parkings = await parkBuddyContext.Parkings.ToListAsync();
            return parkings;
        }
        public async Task<Parking> GetParkingAsync(Guid parkingId)
        {
            var parking = await parkBuddyContext.Parkings.Where(parking => parking.ParkingId == parkingId).FirstOrDefaultAsync();
            return parking;
        }

        public async Task<Parking> RegisterParkingAsync(RegisterParkingDto registerParkingDto)
        {
            var parking = parkingMapper.RegisterDtoToParking(registerParkingDto);

            await parkBuddyContext.Parkings.AddAsync(parking);
            await parkBuddyContext.SaveChangesAsync();

            return parking;
        }

        public async Task<bool> DeleteParkingAsync(Guid parkingId)
        {
            var parking = await parkBuddyContext.Parkings.FindAsync(parkingId);

            if (parking == null)
                return false;

            parkBuddyContext.Remove(parking);

            var result = await parkBuddyContext.SaveChangesAsync();
            if (result >= 1)
                return true;
            return false;
        }
    }
}