using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SP19.P05.Web.Features.Authorization
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}