using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings;

public class CidadeMap : IEntityTypeConfiguration<Cidade>
{
    public void Configure(EntityTypeBuilder<Cidade> builder)
    {
        builder.ToTable("Cidade");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn()
            .HasColumnName("Id");

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("Nome");

        builder.Property(x => x.UF)
            .IsRequired()
            .HasMaxLength(2)
            .HasColumnType("VARCHAR")
            .HasColumnName("UF");

        builder.HasMany(x => x.Pessoas)
                .WithOne(x => x.Cidade)
                .HasConstraintName("FK_Pessoa_Cidade")
                .OnDelete(DeleteBehavior.Cascade);
    }
}
