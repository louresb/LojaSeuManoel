using LojaSeuManoel.Domain.Enums;
using LojaSeuManoel.Domain.ValueObjects;

namespace LojaSeuManoel.Domain.Entities;

public class Caixa
{
    public TipoCaixa Tipo { get; }
    public Dimensao Dimensao { get; }
    public List<Produto> Produtos { get; } = new();

    public int Volume => Dimensao.Volume;

    public Caixa(TipoCaixa tipo)
    {
        Tipo = tipo;
        Dimensao = tipo switch
        {
            TipoCaixa.Caixa1 => new Dimensao(30, 40, 80),
            TipoCaixa.Caixa2 => new Dimensao(80, 50, 40),
            TipoCaixa.Caixa3 => new Dimensao(50, 80, 60),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
