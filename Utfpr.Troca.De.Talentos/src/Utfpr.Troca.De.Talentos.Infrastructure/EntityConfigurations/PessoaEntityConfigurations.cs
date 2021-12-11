using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utfpr.Troca.De.Talentos.Domain.Pessoas;

namespace Utfpr.Troca.De.Talentos.Infrastructure.EntityConfigurations
{
    public class PessoaEntityConfigurations : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PESSOA");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("CDPESSOA")
                .ValueGeneratedOnAdd();
            
            builder.Property(x => x.Campus)
                .IsRequired()
                .HasColumnName("CAMPUS");
            
            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasColumnName("CIDADE");
            
            builder.Property(x => x.Curso)
                .IsRequired()
                .HasColumnName("CURSO");
            
            builder.Property(x => x.Estado)
                .IsRequired()
                .HasColumnName("ESTADO");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("NOME");
            
            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnName("DTCADASTRO");
            
            builder.Property<long>("_usuarioId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CDUSUARIO");

            builder.HasOne(o => o.Usuario)
                .WithOne()
                .HasForeignKey<Usuario>("_usuarioId")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}