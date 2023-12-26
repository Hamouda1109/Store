using Store.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Models.Store;

namespace Store.Data
{
    public class StoreDbContext : IdentityDbContext<User , Role , int>
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
    }
}
