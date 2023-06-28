using System;
using System.Collections.Generic;

#nullable disable

namespace Fitness.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            Defactives = new HashSet<Defactive>();
            Details = new HashSet<Detail>();
        }

        public string EquipmentId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public int? Amount { get; set; }
        public int? UnitId { get; set; }
        public int? Status { get; set; }
        public string Detail { get; set; }
        public byte[] Image { get; set; }
        public string OfficerId { get; set; }

        public virtual Officer Officer { get; set; }
        public virtual CountingUnit Unit { get; set; }
        public virtual ICollection<Defactive> Defactives { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}
