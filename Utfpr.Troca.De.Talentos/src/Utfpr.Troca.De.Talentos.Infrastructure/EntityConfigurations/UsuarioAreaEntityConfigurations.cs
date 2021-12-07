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
            
            builder.Property<long>("_usuarioId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CDUSUARIO");
            builder.HasOne(o => o.Usuario)
                .WithOne()
                .HasForeignKey<Usuario>("_usuarioId")
                .OnDelete(DeleteBehavior.SetNull);
            
            builder.Property<long>("_areaId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CDAREA");
            builder.HasOne(o => o.Area)
                .WithOne()
                .HasForeignKey<Area>("_areaId")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}