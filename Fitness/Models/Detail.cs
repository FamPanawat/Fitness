using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Fitness.Models
{
    public partial class Detail
    {
        [Key]
        public long No { get; set; }
        public string EquipmentId { get; set; }
        public string BorrowingId { get; set; }
        public int? Quantity { get; set; }
        public string ReturnId { get; set; }
        public int? ReturnQuantity { get; set; }
        public string ListstatusId { get; set; }

        public virtual Borrowing Borrowing { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual ListStatus Liststatus { get; set; }
        public virtual Return Return { get; set; }
    }
}
