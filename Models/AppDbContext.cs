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
            modelBuilder.Entity<UsersRole>(entity=>{
                entity.HasKey(u=>new{u.RoleId, u.UsersId});
            });

            modelBuilder.Entity<ProductUsers>(entity=>{
                entity.HasKey(u=>new{u.UsersId, u.ProductId});
            });
            
            
           
        }
        public DbSet<Category> categories{set;get;}
        public DbSet<Product> products{set;get;}
        public DbSet<Users> users{set;get;}
        public DbSet<UsersRole> usersRoles{set;get;}
        public DbSet<Role> roles {set;get;}
        public DbSet<ProductUsers> productUsers{set;get;}
        public DbSet<Order> orders{set;get;}

    }
}