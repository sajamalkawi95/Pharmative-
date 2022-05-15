using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmaviteRole
    {
        public PharmaviteRole()
        {
            PharmaviteUsers = new HashSet<PharmaviteUser>();
        }

        public decimal RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }

        public virtual ICollection<PharmaviteUser> PharmaviteUsers { get; set; }
    }
}
