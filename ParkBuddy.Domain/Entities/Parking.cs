using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Domain.Entities;

public class Parking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ParkingId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public Address Address { get; set; }
    [Required]
    public int Capacity { get; set; }
    [Required]
    public decimal PricePerHour { get; set; }
    [Required]
    public ParkingStatus Status { get; set; } = ParkingStatus.Open;
}