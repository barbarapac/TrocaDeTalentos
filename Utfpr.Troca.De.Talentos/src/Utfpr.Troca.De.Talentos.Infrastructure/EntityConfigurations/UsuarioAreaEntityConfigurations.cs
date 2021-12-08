using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utfpr.Troca.De.Talentos.Domain.Areas;
using Utfpr.Troca.De.Talentos.Domain.Pessoas;

namespace Utfpr.Troca.De.Talentos.Infrastructure.EntityConfigurations
{
    public class UsuarioAreaEntityConfigurations : IEntityTypeConfiguration<UsuarioArea>
    {
        public void Configure(EntityTypeBuilder<UsuarioArea> builder)
        {
            builder.ToTable("USUARIOAREA");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("CDUSUARIOAREA").ValueGeneratedOnAdd();
            builder.Property(x => x.UsuarioId).IsRequired().HasColumnName("CDUSUARIO");
            builder.Property(x => x.AreaId).IsRequired().HasColumnName("CDAREA");
            
            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId)
                .IsRequired();
            
            builder.HasOne(x => x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaId)
                .IsRequired();
            
            builder.Property<long>("_usuarioId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CDUSUARIO");
            
            builder.Property<long>("_areaId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CDAREA");
        }
    }
}