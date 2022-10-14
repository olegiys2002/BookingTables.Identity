using Identity.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
