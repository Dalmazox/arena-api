using Arena.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Arena.Infra.Data.Context
{
    public class ArenaContext : DbContext
    {
        public ArenaContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeamMap).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
