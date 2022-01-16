using ConsoleEFCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFCore
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Product> Products { get; set; }
        
        public DbSet<UserProfile> UserProfiles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        #region
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseMemoryCache();
        //    optionsBuilder.UseSqlServer("Connection");
        //}
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
