using Microsoft.EntityFrameworkCore;
using Account.Models;

namespace Users.Data
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts(DbContextOptions<AppDbContexts> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}