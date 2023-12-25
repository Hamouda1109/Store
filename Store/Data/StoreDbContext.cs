using Store.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Store.Data
{
    public class StoreDbContext : IdentityDbContext<User , Role , int>
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
    }
}
