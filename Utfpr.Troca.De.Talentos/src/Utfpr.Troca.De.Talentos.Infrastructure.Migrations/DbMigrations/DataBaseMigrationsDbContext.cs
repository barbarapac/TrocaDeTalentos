using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Utfpr.Troca.De.Talentos.Infrastructure.Migrations.DbMigrations
{
    public class DataBaseMigrationsDbContext : DbContextMigrations
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            ConvertModelBuilderCase(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.postgres.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        private static void ConvertModelBuilderCase(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(ConvertCase(entity.GetTableName()));
                ConvertIndexes(entity);
                ConvertForeignKeys(entity);
                ConvertKeys(entity);
                ConvertColumns(entity);
            }
        }
        
        private static string ConvertCase(string value)
            => value.ToUpper();

        private static void ConvertIndexes(IMutableEntityType entityType)
        {
            foreach (var index in entityType.GetIndexes()) 
                index.SetName(ConvertCase(index.GetName()));
        }

        private static void ConvertForeignKeys(IMutableEntityType entityType)
        {
            foreach (var index in  entityType.GetForeignKeys())
                index.SetConstraintName(ConvertCase(index.GetConstraintName()));
        }

        private static void ConvertKeys(IMutableEntityType entityType)
        {
            foreach (var index in entityType.GetKeys()) 
                index.SetName(ConvertCase(index.GetName()));
        }

        private static void ConvertColumns(IMutableEntityType entityType)
        {
            foreach (var index in entityType.GetProperties()) 
                index.SetColumnName(ConvertCase(index.GetColumnName()));
        }
    }
}