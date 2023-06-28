using System;
using System.Collections.Generic;

#nullable disable

namespace Fitness.Models
{
    public partial class ListStatus
    {
        public ListStatus()
        {
            Details = new HashSet<Detail>();
        }

        public string ListstatusId { get; set; }
        public string ListstatusName { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
    }
}
