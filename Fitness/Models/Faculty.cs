using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Fitness.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Departments = new HashSet<Department>();
            Members = new HashSet<Member>();
        }
        [Key]
        public string FacultyId { get; set; }
        public string FacultyName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
