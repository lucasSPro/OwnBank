using Microsoft.EntityFrameworkCore;
using GestorAvaliacao.Domain.Entities;

namespace GestorAvaliacao.Infrastructure.DataAccess
{
    public class GestorAvaliacaoDBContext : DbContext
    {
        public GestorAvaliacaoDBContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GestorAvaliacaoDBContext).Assembly);
        }

    }
}
