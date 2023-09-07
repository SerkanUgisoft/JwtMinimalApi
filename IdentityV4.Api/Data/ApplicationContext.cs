using IdentityV4.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityV4.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> context)
            : base(context) {
        }
    }
}
