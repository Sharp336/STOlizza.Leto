using Microsoft.EntityFrameworkCore;
using STOlizza.Leto.Shared;
using System.Configuration;

namespace STOlizza.Leto.Server
{
    public class DatabaseContext : DbContext
    {
        public DbSet<SmenaDTO> Shifts { get; set; }
        public DbSet<QuestionnairyDTO> Answers { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);
        }
    }
}
