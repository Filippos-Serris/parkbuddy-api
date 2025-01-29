using ParkBuddy.Application.Dtos;

namespace ParkBuddy.Application.Interfaces
{
    public interface IParkingRepository
    {
        Task<ParkingDto> GetParkingAsync(Guid parkingId);
        Task<List<ParkingDto>> GetParkingsAsync();
    }
}