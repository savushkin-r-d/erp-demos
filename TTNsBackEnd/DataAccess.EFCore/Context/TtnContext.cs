using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccess.EFCore
{
    public class TtnContext : DbContext
    {
        public TtnContext(DbContextOptions<TtnContext> options) : base(options) { }

        public DbSet<Sttn> Sttns { get; set; }

        public DbSet<Zttn> Zttns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SttnConfiguration());
            builder.ApplyConfiguration(new ZttnConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
