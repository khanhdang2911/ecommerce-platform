using Microsoft.EntityFrameworkCore;

namespace Ecommerce_website.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
                base.OnConfiguring(builder);
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
           
        }
        public DbSet<Category> categories{set;get;}
        public DbSet<Product> products{set;get;}
        public DbSet<User> users{set;get;}
        public DbSet<UserRole> userRoles{set;get;}
        public DbSet<Role> roles {set;get;}

    }
}