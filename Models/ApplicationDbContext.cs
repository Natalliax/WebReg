using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebTest.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<People> People { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MastSchedule> MastSchedules { get; set; }
       
        public DbSet<NameService> NameServices { get; set; }


        

    }
}
