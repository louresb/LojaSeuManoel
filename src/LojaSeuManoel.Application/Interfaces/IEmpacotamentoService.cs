using LojaSeuManoel.Domain.Entities;

namespace LojaSeuManoel.Application.Interfaces;

public interface IEmpacotamentoService
{
    List<Caixa> Empacotar(Pedido pedido);
}
