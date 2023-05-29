using Microsoft.EntityFrameworkCore;
using STOlizza.Leto.Shared;
using System.Configuration;

namespace STOlizza.Leto.Server
{
    public class DatabaseContext : DbContext
    {
        public DbSet<SmenaDTO> Smenas { get; set; }
        public DbSet<QuestionnairyDTO> Records { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);
        }
        public DbSet<STOlizza.Leto.Shared.QuestionnairyDTO>? QuestionnaireClientDTO { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(System.Configuration.ConfigurationManager.ConnectionStrings["RemoteConnectionString1"] .ConnectionString);
        //}
    }
}
