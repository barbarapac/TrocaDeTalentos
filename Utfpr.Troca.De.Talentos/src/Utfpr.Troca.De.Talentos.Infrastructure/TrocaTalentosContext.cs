using System;
using Microsoft.EntityFrameworkCore;
using Utfpr.Troca.De.Talentos.Domain.Pessoas;
using Utfpr.Troca.De.Talentos.Domain.Usuario;
using Utfpr.Troca.De.Talentos.Domain.UsuarioArea;

namespace Utfpr.Troca.De.Talentos.Infrastructure
{
    public class TrocaTalentosContext : DbContext
    {
        
        public TrocaTalentosContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrocaTalentosContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<UsuarioArea> UsuarioArea { get; set; }
        public DbSet<Usuario> Area { get; set; }
    }
}