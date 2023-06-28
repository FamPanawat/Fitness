using Fitness.Models;
using Microsoft.EntityFrameworkCore;

namespace Fitness.Data
{
    public class FitnessDBContext : DbContext
    {
        public FitnessDBContext(DbContextOptions<FitnessDBContext> options)
            : base(options)
        {
        }

        public DbSet<Officer> Officer { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<Role> Role { get; set; }


    }
}
