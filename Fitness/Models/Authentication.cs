using Fitness.Data;
using Fitness.Helpers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Fitness.Models
{
    public class Authentication
    {
        [Required]
        public string Username { get; set;}

        [Required]
        public string Password { get; set;}



    }


}
