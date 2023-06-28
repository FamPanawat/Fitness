using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Fitness.Models
{
    public partial class Officer
    {
        public Officer()
        {
            Borrowings = new HashSet<Borrowing>();
            Equipment = new HashSet<Equipment>();
            Members = new HashSet<Member>();
            Returns = new HashSet<Return>();
        }

        [Key]
        public string Officer_Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SexId { get; set; }
        public string Phone_number { get; set; }
        public DateTime CreateDate { get; set; }
        public int? RoleId { get; set; }
        public string CreateBy { get; set; }

        public virtual Role Role { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual ICollection<Borrowing> Borrowings { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Return> Returns { get; set; }
    }
}
