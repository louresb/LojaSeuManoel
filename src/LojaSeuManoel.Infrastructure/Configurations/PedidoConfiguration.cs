using LojaSeuManoel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaSeuManoel.Infrastructure.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.Produtos)
               .WithOne()
               .HasForeignKey("PedidoId")
               .OnDelete(DeleteBehavior.Cascade);
    }
}
