using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ParkBuddy.Domain.Entities;

/// <summary>
/// Represents a user entity.
/// </summary>
public class User : IdentityUser<Guid> // <Guid> => set the primary key to Guid
{
    /// <summary>
    /// The first name of the user.
    /// </summary>
    [Required]
    public string FirstName { get; set; }

    /// <summary>
    /// The last name of the user.
    /// </summary>
    [Required]
    public string LastName { get; set; }

    /// <summary>
    /// Navigation property for the parkings associated with the user.
    /// </summary>
    public ICollection<Parking>? Parkings { get; set; } = new List<Parking>();
}
