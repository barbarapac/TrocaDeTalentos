using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utfpr.Troca.De.Talentos.Domain.Pessoas;
using Utfpr.Troca.De.Talentos.Domain.Usuario;

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
                .HasColumnName("IDPESSOA")
                .ValueGeneratedOnAdd();
            
            builder.Property(x => x.Campus)
                .HasColumnName("CAMPUS");
            
            builder.Property(x => x.Cidade)
                .HasColumnName("CIDADE");
            
            builder.Property(x => x.Curso)
                .HasColumnName("CURSO");
            
            builder.Property(x => x.Estado)
                .HasColumnName("ESTADO");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("NOME");
            
            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnName("DTCADASTRO");
            
            builder.Property(x => x.UsuarioId)
                .IsRequired()
                .HasColumnName("IDUSUARIO");
            
            builder.Property(x => x.FotoPerfil)
                .HasColumnName("FOTOPERFIL");
            
            builder.HasOne(x => x.Usuario)
                .WithOne()
                .HasForeignKey<Usuario>(x => x.Id)
                .IsRequired();
        }
    }
}