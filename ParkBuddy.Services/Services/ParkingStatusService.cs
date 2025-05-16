using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Services.Services
{
    public class ParkingStatusService
    {
        public ParkingStatus GetParkingStatus(Parking parking, int reservedSPaces)
        {
            return parking.Status;
        }
    }
}