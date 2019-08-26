using Microsoft.EntityFrameworkCore;

namespace HBSIS.Padawan.Infra.Context
{
    public class GaragemContext : DbContext
    {
        public GaragemContext(DbContextOptions<GaragemContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GaragemContext).Assembly);
        }
    }
}
