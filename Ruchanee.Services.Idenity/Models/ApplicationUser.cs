using Microsoft.AspNetCore.Identity;

namespace Ruchanee.Services.Idenity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
