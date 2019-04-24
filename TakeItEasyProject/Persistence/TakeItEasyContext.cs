using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class TakeItEasyContext : DbContext
    {
        public TakeItEasyContext(DbContextOptions<TakeItEasyContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
