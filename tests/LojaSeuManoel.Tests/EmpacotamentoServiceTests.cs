using LojaSeuManoel.Application.Services;
using LojaSeuManoel.Domain.Entities;
using LojaSeuManoel.Domain.Enums;
using LojaSeuManoel.Domain.ValueObjects;
using LojaSeuManoel.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LojaSeuManoel.Tests.Services
{
    public class EmpacotamentoServiceTests
    {
        private LojaDbContext CriarContextoEmMemoria()
        {
            var options = new DbContextOptionsBuilder<LojaDbContext>()
                .UseInMemoryDatabase(databaseName: "LojaDbTest")
                .Options;

            return new LojaDbContext(options);
        }

        [Fact]
        public void Empacotar_DeveDistribuirProdutosEmCaixasApropriadas()
        {
            var context = CriarContextoEmMemoria();
            var service = new EmpacotamentoService(context);

            var pedido = new Pedido();
            pedido.Produtos.Add(new Produto("Produto1", new Dimensao(30, 40, 80))); 
            pedido.Produtos.Add(new Produto("Produto2", new Dimensao(80, 50, 40))); 
            pedido.Produtos.Add(new Produto("Produto3", new Dimensao(50, 80, 60))); 

            var caixas = service.Empacotar(pedido);

            Assert.Equal(3, caixas.Count);
            Assert.Contains(caixas, c => c.Tipo == TipoCaixa.Caixa1 && c.Produtos.Any(p => p.Nome == "Produto1"));
            Assert.Contains(caixas, c => c.Tipo == TipoCaixa.Caixa2 && c.Produtos.Any(p => p.Nome == "Produto2"));
            Assert.Contains(caixas, c => c.Tipo == TipoCaixa.Caixa3 && c.Produtos.Any(p => p.Nome == "Produto3"));
        }

        [Fact]
        public void Empacotar_DeveAproveitarEspacoEmCaixaJaExistente()
        {
            var context = CriarContextoEmMemoria();
            var service = new EmpacotamentoService(context);

            var pedido = new Pedido();
            pedido.Produtos.Add(new Produto("Produto1", new Dimensao(1, 2, 2))); 
            pedido.Produtos.Add(new Produto("Produto2", new Dimensao(1, 1, 5))); 

            var caixas = service.Empacotar(pedido);

            Assert.Single(caixas);
            Assert.Equal(TipoCaixa.Caixa1, caixas[0].Tipo);
            Assert.Equal(2, caixas[0].Produtos.Count);
        }

        [Fact]
        public void Empacotar_DeveLancarErro_SeProdutoNaoCouberEmNenhumaCaixa()
        {
            var context = CriarContextoEmMemoria();
            var service = new EmpacotamentoService(context);

            var pedido = new Pedido();
            pedido.Produtos.Add(new Produto("Gigante", new Dimensao(100, 100, 100))); 

            var ex = Assert.Throws<InvalidOperationException>(() => service.Empacotar(pedido));
            Assert.Contains("Nenhuma caixa disponível comporta o produto", ex.Message);
        }
    }
}
