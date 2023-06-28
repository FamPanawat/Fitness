using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Fitness.Models
{
    public partial class CountingUnit
    {
        public CountingUnit()
        {
            Equipment = new HashSet<Equipment>();
        }

        [Key]
        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
