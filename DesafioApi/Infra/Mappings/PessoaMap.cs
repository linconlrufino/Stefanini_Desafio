using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings;

public class PessoaMap : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoa");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn()
            .HasColumnName("Id");

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasMaxLength(300)
            .HasColumnType("VARCHAR");

        builder.Property(x => x.CPF)
            .IsRequired()
            .HasMaxLength(11)
            .HasColumnName("CPF")
            .HasColumnType("VARCHAR");

        builder.HasOne(x => x.Cidade)
            .WithMany(x => x.Pessoas)
            .HasConstraintName("FK_Pessoa_Cidade")
            .OnDelete(DeleteBehavior.Cascade); ;

        builder.Property(x => x.Idade)
            .IsRequired()
            .HasColumnName("Idade")
            .HasColumnType("NUMERIC");
    }
}
