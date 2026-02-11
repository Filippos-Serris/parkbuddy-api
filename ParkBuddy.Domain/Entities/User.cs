using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParkBuddy.Domain.Entities;

public class User : IdentityUser<Guid> // <Guid> => set the primary key to Guid
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
}
