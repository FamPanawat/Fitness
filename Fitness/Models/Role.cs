using System;
using System.Collections.Generic;

#nullable disable

namespace Fitness.Models
{
    public partial class Role
    {
        public Role()
        {
            Members = new HashSet<Member>();
            Officers = new HashSet<Officer>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Officer> Officers { get; set; }
    }
}
