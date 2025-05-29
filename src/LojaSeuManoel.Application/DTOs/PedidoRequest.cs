namespace LojaSeuManoel.Application.DTOs;

public class PedidoRequest
{
    public List<ProdutoRequest> Produtos { get; set; } = new();
}
