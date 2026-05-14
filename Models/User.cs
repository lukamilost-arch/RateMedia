using Microsoft.AspNetCore.Identity;

namespace RateMedia.Models
{
    public class User : IdentityUser
    {
        public string? DisplayName { get; set; }
        public bool VerifyUser()
        {
            return !string.IsNullOrEmpty(Id);
        }
    }
}