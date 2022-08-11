using Microsoft.AspNetCore.Identity;

namespace AngularWebApp.Data.Entities.Users.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
