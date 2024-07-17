using Microsoft.EntityFrameworkCore;
using WarriorsAndMagesRPG.Infrastructure.Models;

namespace WarriorsAndMagesRPG.Infrastructure
{
    public class WarriorsAndMagesContext : DbContext
    {
        public WarriorsAndMagesContext() { }

        public WarriorsAndMagesContext(DbContextOptions options) : base(options) { }

        public DbSet<CharacterEntity> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configure.connectionString);
            }
        }
    }
}
