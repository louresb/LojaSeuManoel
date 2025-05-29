using LojaSeuManoel.Domain.Entities;

namespace LojaSeuManoel.Domain.Interfaces.Repositories;

public interface IPedidoRepository
{
    Task AdicionarAsync(Pedido pedido);
    Task SalvarAsync();
}
