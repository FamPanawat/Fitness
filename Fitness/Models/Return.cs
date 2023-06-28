using System;
using System.Collections.Generic;

#nullable disable

namespace Fitness.Models
{
    public partial class Return
    {
        public Return()
        {
            Details = new HashSet<Detail>();
        }

        public string ReturnId { get; set; }
        public DateTime? Returndate { get; set; }
        public string Idcard { get; set; }
        public string OfficeId { get; set; }

        public virtual Member IdcardNavigation { get; set; }
        public virtual Officer Office { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}
