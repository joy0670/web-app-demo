using Microsoft.EntityFrameworkCore;

namespace webapi.Data
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions<MongoDBContext> options) : base(options)
        {
        }

        public DbSet<endWip> EndWipModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<endWip>().HasKey(e => e.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
