using LojaSeuManoel.Application.Interfaces;
using LojaSeuManoel.Domain.Entities;
using LojaSeuManoel.Domain.Enums;
using LojaSeuManoel.Infrastructure.Context;

namespace LojaSeuManoel.Application.Services;

public class EmpacotamentoService : IEmpacotamentoService
{
    private readonly LojaDbContext _context;

    private readonly List<TipoCaixa> _ordemCaixas = new()
    {
        TipoCaixa.Caixa1,
        TipoCaixa.Caixa2,
        TipoCaixa.Caixa3
    };

    public EmpacotamentoService(LojaDbContext context)
    {
        _context = context;
    }

    public List<Caixa> Empacotar(Pedido pedido)
    {
        var produtosOrdenados = pedido.Produtos
            .OrderByDescending(p => p.Volume)
            .ToList();

        var caixas = new List<Caixa>();

        foreach (var produto in produtosOrdenados)
        {
            var caixaExistente = caixas.FirstOrDefault(c =>
                c.Produtos.Sum(p => p.Volume) + produto.Volume <= c.Volume);

            if (caixaExistente != null)
            {
                caixaExistente.Produtos.Add(produto);
            }
            else
            {
                var novaCaixa = SelecionarMenorCaixaQueComporta(produto);
                novaCaixa.Produtos.Add(produto);
                caixas.Add(novaCaixa);
            }
        }

        _context.Pedidos.Add(pedido);
        _context.SaveChanges();

        return caixas;
    }

    private Caixa SelecionarMenorCaixaQueComporta(Produto produto)
    {
        foreach (var tipo in _ordemCaixas)
        {
            var caixa = new Caixa(tipo);
            if (produto.Volume <= caixa.Volume)
                return caixa;
        }

        throw new InvalidOperationException($"Nenhuma caixa disponível comporta o produto {produto.Nome}.");
    }
}
