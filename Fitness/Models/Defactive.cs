using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Fitness.Models
{
    public partial class Defactive
    {
        [Key]
        public long No { get; set; }
        public string EquipmentId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Transactiondate { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
