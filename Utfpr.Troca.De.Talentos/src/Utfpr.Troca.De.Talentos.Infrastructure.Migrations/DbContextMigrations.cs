using Microsoft.EntityFrameworkCore;

namespace Utfpr.Troca.De.Talentos.Infrastructure.Migrations
{
    public class DbContextMigrations : DbContext
    {
        public const string MigrationHistoryTable = "__MigrationsHistory";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(TrocaTalentosContext.DbSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrocaTalentosContext).Assembly);
        }
    }
}