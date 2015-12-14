using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityTutorial.Models
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
    public class UserRoles
    {
        public int UserRoleId { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Roles Role { get; set; }
    }
}