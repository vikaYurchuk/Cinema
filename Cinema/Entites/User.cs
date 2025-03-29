using Microsoft.AspNetCore.Identity;

namespace Cinema.Entities;

public class User : IdentityUser
{
    public DateTime Birthdate { get; set; }
}