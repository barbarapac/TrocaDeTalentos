using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utfpr.Troca.De.Talentos.Domain.Pessoas;

namespace Utfpr.Troca.De.Talentos.Infrastructure.EntityConfigurations
{
    public class UsuarioEntityConfigurations : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("CDUSUARIO")
                .ValueGeneratedOnAdd();
            
            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("EMAIL");
            
            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnName("SENHA");
            
            builder.Property(x => x.Ra)
                .IsRequired()
                .HasColumnName("RA");
        }
    }
}