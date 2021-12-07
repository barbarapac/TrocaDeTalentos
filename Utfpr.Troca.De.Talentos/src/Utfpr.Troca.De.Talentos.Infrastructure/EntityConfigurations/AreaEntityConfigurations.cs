using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utfpr.Troca.De.Talentos.Domain.Areas;

namespace Utfpr.Troca.De.Talentos.Infrastructure.EntityConfigurations
{
    public class AreaEntityConfigurations : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("AREA");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("CDAREA").ValueGeneratedOnAdd();
            
            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnName("DESCRICAO");
        }
    }
}