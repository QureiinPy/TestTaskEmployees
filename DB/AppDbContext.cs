using Microsoft.EntityFrameworkCore;
using WorkConsole.Model;
using System.IO;

namespace WorkConsole.DB
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.LogTo(Console.WriteLine);

            optionsBuilder.UseNpgsql("Host=localhost;Database=Work;Username=postgres;Password=Postqwerty");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
