using Microsoft.EntityFrameworkCore;

namespace ConfigManagementDemo.Models
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<ConfigurationItem> ConfigurationItems { get; set; }
        
        public DbSet<DependencyItem> DependencyItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ConfigurationItemsDemo;User=sa;Password=Wepsys123@;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DependencyItem>()
                .HasOne(di => di.BaseCi)
                .WithMany(ci => ci.DependencyItems)
                .HasForeignKey(di => di.BaseCiName);

            modelBuilder.Entity<DependencyItem>()
                .HasOne(di => di.DependencyCi)
                .WithMany(ci => ci.ItemsThatDepend)
                .HasForeignKey(di => di.DependencyCiName);
        }
    }
}