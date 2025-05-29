using LojaSeuManoel.Application.DTOs;
using LojaSeuManoel.Domain.Entities;
using LojaSeuManoel.Domain.ValueObjects;

namespace LojaSeuManoel.Application.Mappers;

public static class PedidoMapper
{
    public static Pedido MapToEntity(PedidoRequest dto)
    {
        var produtos = dto.Produtos.Select(p =>
            new Produto(p.Nome, new Dimensao(p.Altura, p.Largura, p.Comprimento))
        ).ToList();

        return new Pedido(produtos);
    }

    public static PedidoResponse MapToResponse(List<Caixa> caixas)
    {
        return new PedidoResponse
        {
            Caixas = caixas.Select(c => new CaixaResponse
            {
                Tipo = c.Tipo.ToString(),
                Altura = c.Dimensao.Altura,
                Largura = c.Dimensao.Largura,
                Comprimento = c.Dimensao.Comprimento,
                Produtos = c.Produtos.Select(p => new ProdutoResponse
                {
                    Nome = p.Nome,
                    Altura = p.Dimensao.Altura,
                    Largura = p.Dimensao.Largura,
                    Comprimento = p.Dimensao.Comprimento
                }).ToList()
            }).ToList()
        };
    }
}
