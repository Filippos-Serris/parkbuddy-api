using ParkBuddy.Application.Common;
using ParkBuddy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkBuddy.Domain.Repositories
{
    public interface IParkingRepository
    {
        Task<Result<List<Parking>>> GetParkingListAsync();
        Task<Result<Parking>> GetParkingAsync(Guid parkingId);
        Task<Result<string>> DeleteParkingAsync(Guid parkingId);
        Task<Result<bool>> RegisterParkingAsync(Parking parking);
    }
}