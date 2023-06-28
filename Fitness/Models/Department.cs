using System;
using System.Collections.Generic;

#nullable disable

namespace Fitness.Models
{
    public partial class Department
    {
        public Department()
        {
            Members = new HashSet<Member>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
