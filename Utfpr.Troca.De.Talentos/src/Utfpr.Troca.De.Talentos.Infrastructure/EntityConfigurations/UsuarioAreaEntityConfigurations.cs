using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utfpr.Troca.De.Talentos.Domain.Pessoas;

namespace Utfpr.Troca.De.Talentos.Infrastructure.EntityConfigurations
{
    public class UsuarioAreaEntityConfigurations : IEntityTypeConfiguration<UsuarioArea>
    {
        public void Configure(EntityTypeBuilder<UsuarioArea> builder)
        {
            builder.ToTable("ATIVIDADE");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("CDUSUARIOAREA").ValueGeneratedOnAdd();//.HasSequence(Sequence.ATIVIDADE);
            
            builder.Property<long>("_secaoId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CDSECAO");

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.Id)
                .IsRequired();
            
            builder.HasMany(x => x.Areas)
                .WithOne()
                .HasForeignKey(x => x.Id);
        }
    }
}