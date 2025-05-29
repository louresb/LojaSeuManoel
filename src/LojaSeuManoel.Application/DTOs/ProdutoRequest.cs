namespace LojaSeuManoel.Application.DTOs;

public class ProdutoRequest
{
    public string Nome { get; set; } = string.Empty;
    public int Altura { get; set; }
    public int Largura { get; set; }
    public int Comprimento { get; set; }
}
