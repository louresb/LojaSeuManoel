namespace LojaSeuManoel.Domain.Entities;

public class Pedido
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Produto> Produtos { get; set; } = new();

    public Pedido(List<Produto> produtos)
    {
        Produtos = produtos;
    }
}
