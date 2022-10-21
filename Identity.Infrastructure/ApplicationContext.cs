using Identity.Infrastructure.Views;
using Identity.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Identity.Infrastructure
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserAvatarsDTO> UserAvatars { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserAvatarsDTO>().ToView(nameof(UserAvatars)); 
            builder.Entity<Role>().HasData(new Role { Name = "Admin" , NormalizedName = "Admin"});
            builder.Entity<Role>().HasData(new Role { Name = "User", NormalizedName = "User" });
            
            base.OnModelCreating(builder);
        }
    }
}
