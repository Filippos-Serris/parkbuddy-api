using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Contracts.Dtos
{
    public class RegisterParkingDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerHour { get; set; }
        public ParkingStatus Status { get; set; } = ParkingStatus.Open;
    }
}