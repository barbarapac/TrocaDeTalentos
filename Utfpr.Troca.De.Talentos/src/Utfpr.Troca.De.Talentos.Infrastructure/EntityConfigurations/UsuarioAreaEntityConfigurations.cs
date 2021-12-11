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
            builder.Property(x => x.Id).IsRequired().HasColumnName("IDUSUARIOAREA").ValueGeneratedOnAdd();
            
            builder.Property<long>("_usuarioId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IDUSUARIO");
            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Areas)
                .HasForeignKey("_usuarioId")
                .IsRequired();

            builder.Property<long>("_areaId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IDAREA");
            builder.HasOne(x => x.Area)
                .WithMany()
                .HasForeignKey("_areaId")
                .IsRequired();
        }
    }
}