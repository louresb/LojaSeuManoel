namespace LojaSeuManoel.Application.DTOs;

public class CaixaResponse
{
    public string Tipo { get; set; } = string.Empty;
    public int Altura { get; set; }
    public int Largura { get; set; }
    public int Comprimento { get; set; }
    public List<ProdutoResponse> Produtos { get; set; } = new();
}
