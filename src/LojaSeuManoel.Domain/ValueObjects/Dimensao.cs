namespace LojaSeuManoel.Domain.ValueObjects;

public class Dimensao
{
    public int Altura { get; }
    public int Largura { get; }
    public int Comprimento { get; }

    public int Volume => Altura * Largura * Comprimento;

    public Dimensao(int altura, int largura, int comprimento)
    {
        if (altura <= 0 || largura <= 0 || comprimento <= 0)
            throw new ArgumentException("Todas as dimensões devem ser maiores que zero.");

        Altura = altura;
        Largura = largura;
        Comprimento = comprimento;
    }

    public override string ToString()
        => $"{Altura}x{Largura}x{Comprimento}";

    public override bool Equals(object? obj)
    {
        if (obj is not Dimensao other) return false;
        return Altura == other.Altura &&
               Largura == other.Largura &&
               Comprimento == other.Comprimento;
    }

    public override int GetHashCode()
        => HashCode.Combine(Altura, Largura, Comprimento);
}
