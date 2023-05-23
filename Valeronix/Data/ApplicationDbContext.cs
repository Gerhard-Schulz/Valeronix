using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Valeronix.Models.DatabaseModels;

namespace Valeronix.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Computer> Computer { get; set; }
        public DbSet<Creator> Creator { get; set; }
        public DbSet<Keyboard> Keyboard { get; set; }
        public DbSet<ModelOfDevice> ModelOfDevice { get; set; }
        public DbSet<MonitorMagaz> MonitorMagaz { get; set; }
        public DbSet<Mouse> Mouse { get; set; }
        public DbSet<OS> OS { get; set; }
        public DbSet<Processor> Processor { get; set; }
        public DbSet<VideoCard> VideoCard { get; set; }

        public ApplicationDbContext() => Database.EnsureCreated();
        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
    }
}
