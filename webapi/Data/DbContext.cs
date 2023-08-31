using Microsoft.EntityFrameworkCore;


namespace webapi.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
