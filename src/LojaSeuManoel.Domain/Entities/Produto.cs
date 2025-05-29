using LojaSeuManoel.Domain.ValueObjects;

namespace LojaSeuManoel.Domain.Entities;

public class Produto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public Dimensao Dimensao { get; set; } = null!;

    public int Volume => Dimensao.Volume;

    public Produto() { }

    public Produto(string nome, Dimensao dimensao)
    {
        Nome = nome;
        Dimensao = dimensao;
    }
}
