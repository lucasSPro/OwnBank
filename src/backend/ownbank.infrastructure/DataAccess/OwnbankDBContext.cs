using Microsoft.EntityFrameworkCore;
using ownbank.Domain.Entities;

namespace ownbank.Infrastructure.DataAccess
{
    public class OwnbankDBContext: DbContext
    {
        public OwnbankDBContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OwnbankDBContext).Assembly);
        }

    }
}
