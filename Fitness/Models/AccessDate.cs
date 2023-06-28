using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Fitness.Models
{
    public partial class AccessDate
    {
        [Key]
        public long No { get; set; }
        public DateTime? DatetimeSignup { get; set; }
        public string Idcard { get; set; }

        public virtual Member IdcardNavigation { get; set; }
    }
}
