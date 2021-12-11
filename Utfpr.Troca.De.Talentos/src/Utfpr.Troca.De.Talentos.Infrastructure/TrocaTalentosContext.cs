using System;
using Microsoft.EntityFrameworkCore;
using Utfpr.Troca.De.Talentos.Domain.Pessoas;

namespace Utfpr.Troca.De.Talentos.Infrastructure
{
    public class TrocaTalentosContext : DbContext
    {
        
        public const string DbSchema = "UTFPR";
        
        public TrocaTalentosContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DbSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrocaTalentosContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<UsuarioArea> UsuarioArea { get; set; }
        public DbSet<Usuario> Area { get; set; }
    }
}