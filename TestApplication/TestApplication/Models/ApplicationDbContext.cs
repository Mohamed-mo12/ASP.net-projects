using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace TestApplication.Models
{
    public class ApplicationDbContext : DbContext 
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial catalog=CourseDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> trainees  { get; set; }
        public DbSet<Crsresult>  crsresults { get; set; }

    }
}
