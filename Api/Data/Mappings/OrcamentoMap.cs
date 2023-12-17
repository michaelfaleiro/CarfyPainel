using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mappings;
public class OrcamentoMap : IEntityTypeConfiguration<Orcamento>
{
    public void Configure(EntityTypeBuilder<Orcamento> builder)
    {
        builder
            .ToTable("Orcamento");

        builder
            .HasKey("Id");
        builder
            .Property(x => x.Id);

        builder
            .Property(x => x.Cliente)
            .IsRequired()
            .HasColumnName("Cliente")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);

        builder
            .Property(x => x.Veiculo)
            .HasColumnName("Veiculo")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);
        builder
            .Property(x => x.Placa)
            .HasColumnName("Placa")
            .HasColumnType("VARCHAR")
            .HasMaxLength(8);

        builder
            .Property(x => x.Chassi)
            .HasColumnName("Chassi")
            .HasColumnType("VARCHAR")
            .HasMaxLength(17);

        builder
            .Property(x => x.DataCriacao)
            .IsRequired()
            .HasColumnName("DataCriacao")
            .HasColumnType("SMALLDATETIME");
            

        builder
            .HasIndex(x => x.Cliente, "IX_Orcamento_Cliente")
            .IsUnique();

        builder
            .HasMany(x => x.Produtos);
            
    }
}
