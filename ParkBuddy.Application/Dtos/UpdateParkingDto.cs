using ParkBuddy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBuddy.Application.Dtos
{
    public class UpdateParkingDto
    {
        public Guid ParkingId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerHour { get; set; }
        public ParkingStatus Status { get; set; }
    }
}
