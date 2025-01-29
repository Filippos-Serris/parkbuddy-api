namespace ParkBuddy.Application.Dtos
{
    public class ParkingDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerHour { get; set; }
    }
}