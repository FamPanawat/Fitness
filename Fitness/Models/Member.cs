using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Fitness.Models
{
    public partial class Member
    {
        public Member()
        {
            AccessDates = new HashSet<AccessDate>();
            Borrowings = new HashSet<Borrowing>();
            Returns = new HashSet<Return>();
        }

        [Key]
        public string Idcard { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StudentCode { get; set; }
        public string FacultyId { get; set; }
        public int? DepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public string SexId { get; set; }
        public bool Status  { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public DateTime? SuspensionDate { get; set; }
        public string OfficerId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Officer Officer { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual ICollection<AccessDate> AccessDates { get; set; }
        public virtual ICollection<Borrowing> Borrowings { get; set; }
        public virtual ICollection<Return> Returns { get; set; }
    }
}
