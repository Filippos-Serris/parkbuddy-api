using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Contracts.Dtos
{
    public class ParkingDto
    {
        public Guid ParkingId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerHour { get; set; }
        public ParkingStatus Status { get; set; }
    }
}
