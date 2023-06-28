using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Fitness.Models
{
    public partial class Sex
    {
        public Sex()
        {
            Member = new HashSet<Member>();
            Officer = new HashSet<Officer>();
        }

        [Key]
        public string SexId { get; set; }
        public string SexName { get; set; }

        public virtual ICollection<Member> Member { get; set; }
        public virtual ICollection<Officer> Officer { get; set; }
    }
}
