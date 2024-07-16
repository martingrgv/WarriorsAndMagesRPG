using Microsoft.EntityFrameworkCore;

namespace WarriorsAndMagesRPG.Infrastructure
{
    public class WarriorsAndMagesContext : DbContext
    {
        public WarriorsAndMagesContext()
        {
            
        }

        public WarriorsAndMagesContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configure.connectionString);
            }
        }
    }
}
