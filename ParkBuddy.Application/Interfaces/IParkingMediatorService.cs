using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBuddy.Application.Interfaces
{
    public interface IParkingMediatorService
    {
        Task<Result<List<ParkingDto>>> GetParkings();
        Task<Result<ParkingDto>> GetParking(Guid parkingId);
        Task<Result<Guid>> RegisterParking(RegisterParkingDto parking);
        Task<Result<string>> DeleteParking(Guid parkingId);
    }
}
