using LojaSeuManoel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaSeuManoel.Infrastructure.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsOne(p => p.Dimensao, d =>
        {
            d.Property(x => x.Altura).HasColumnName("Altura").IsRequired();
            d.Property(x => x.Largura).HasColumnName("Largura").IsRequired();
            d.Property(x => x.Comprimento).HasColumnName("Comprimento").IsRequired();
        });
    }
}
