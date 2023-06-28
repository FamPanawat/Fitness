using System;
using System.Collections.Generic;

#nullable disable

namespace Fitness.Models
{
    public partial class Borrowing
    {
        public Borrowing()
        {
            Details = new HashSet<Detail>();
        }

        public string BorrowingId { get; set; }
        public DateTime? Borrowingdate { get; set; }
        public string Idcard { get; set; }
        public string OfficeId { get; set; }

        public virtual Member IdcardNavigation { get; set; }
        public virtual Officer Office { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}
