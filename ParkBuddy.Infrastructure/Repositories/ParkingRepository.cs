using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Dtos;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Mappings;
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
        public async Task<List<ParkingDto>> GetParkingsAsync() // to be parking Dto
        {
            var parkings = await parkBuddyContext.Parkings.ToListAsync();
            var parkingDtos = parkingMapper.MapToListDto(parkings);

            return parkingDtos;
        }
        public async Task<ParkingDto> GetParkingAsync(Guid parkingId)
        {
            var parking = await parkBuddyContext.Parkings.Where(parking => parking.ParkingId == parkingId).FirstOrDefaultAsync();
            var parkingDto = parkingMapper.MapToDto(parking);
            return parkingDto;
        }
    }
}