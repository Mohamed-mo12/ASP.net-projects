using Microsoft.Identity;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace E_commerce.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GameDevice>().HasKey(x => new { x.DeviceId, x.GameId });
            builder.Entity<Category>().HasData(new Category[] { 
            new Category{Id= 1 , Name = "Sports" },
            new Category{Id=2 , Name="Action"},
            new Category{Id= 3 , Name = "Adventure" },
            new Category{Id=4 , Name="Racing"},
            new Category{Id= 5 , Name = "Fighting" },
            new Category{Id=6 , Name="Film"},
            });

            builder.Entity<Device>().HasData(new Device[] {

            new Device{Id=1, Name="Playstation",Icon="bi bi-playstation"},
             new Device{Id=2, Name="Xbox",Icon="bi bi-xbox"},
               new Device{Id=3, Name="Nintendo Switch",Icon="bi bi-nintendo-switch"},
             new Device{Id=4, Name="PC",Icon="bi bi-display" }

});

            base.OnModelCreating(builder);
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }

    }
}
