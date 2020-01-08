using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GoalsManager.Areas.Identity.Data
{
    public class GoalsManagerUser : IdentityUser
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public ICollection<Models.Goals> Goals { get; set; }
    }
}
