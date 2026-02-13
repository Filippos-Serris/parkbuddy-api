using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Domain.Entities;

/// <summary>
/// Represents a parking entity.
/// </summary>
public class Parking
{
    /// <summary>
    /// The unique identifier for the parking.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ParkingId { get; set; }

    /// <summary>
    /// The unique identifier of the user who owns the parking.
    /// </summary>
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    /// <summary>
    /// The name of the parking.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// The address of the parking.
    /// </summary>
    [Required]
    public Address Address { get; set; }

    /// <summary>
    /// The capacity of the parking (number of parking spaces).
    /// </summary>
    [Required]
    public int Capacity { get; set; }

    /// <summary>
    /// The price per hour for parking.
    /// </summary>
    [Required]
    public decimal PricePerHour { get; set; }

    /// <summary>
    /// The status of the parking (Open, Closed, Full).
    /// </summary>
    [Required]
    public ParkingStatus Status { get; set; } = ParkingStatus.Open;

    /// <summary>
    /// Navigation property to the User entity.
    /// </summary>
    public User User { get; set; }
}