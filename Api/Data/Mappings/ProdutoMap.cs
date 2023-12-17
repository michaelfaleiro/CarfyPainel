using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mappings;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder
            .ToTable("Produto");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Quantidade)
            .IsRequired()
            .HasColumnName("Quantidade")
            .HasColumnType("INT");

        builder
            .Property(x => x.Sku)
            .HasColumnName("Sku")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder
            .Property(x => x.NomeProduto)
            .IsRequired()
            .HasColumnName("NomeProduto")
            .HasColumnType("VARCHAR")
            .HasMaxLength(180);

        builder
            .Property(x => x.Marca)
            .HasColumnName("Marca")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);

        builder
            .Property(x => x.PrecoCusto)
            .IsRequired()
            .HasColumnName("PrecoCusto")
            .HasColumnType("MONEY");

        builder
            .Property(x => x.PrecoVenda)
            .IsRequired()
            .HasColumnName("PrecoVenda")
            .HasColumnType("MONEY");

        builder
            .Property(x => x.Link)
            .HasColumnName("Link")
            .HasColumnType("TEXT");

        builder
            .Property(x => x.Observacao)
            .HasColumnName("Observacao")
            .HasColumnType("TEXT");

        builder
            .Property(x => x.DataCriacao)
            .IsRequired()
            .HasColumnName("DataCriacao")
            .HasColumnType("SMALLDATETIME");

        builder
            .HasOne(x => x.Orcamento)
            .WithMany(x => x.Produtos)
            .HasConstraintName("FK_Produto_Orcamento")
            .OnDelete(DeleteBehavior.Cascade);
    }
}