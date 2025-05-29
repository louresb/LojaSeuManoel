using Microsoft.AspNetCore.Mvc;
using LojaSeuManoel.Application.DTOs;
using LojaSeuManoel.Application.Interfaces;
using LojaSeuManoel.Application.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace LojaSeuManoel.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EmpacotamentoController : ControllerBase
{
    private readonly IEmpacotamentoService _empacotamentoService;

    public EmpacotamentoController(IEmpacotamentoService empacotamentoService)
    {
        _empacotamentoService = empacotamentoService;
    }

    [HttpPost]
    public IActionResult EmpacotarPedidos([FromBody] List<PedidoRequest> pedidos)
    {
        if (pedidos == null || !pedidos.Any())
            return BadRequest("A lista de pedidos está vazia.");

        var responses = new List<PedidoResponse>();

        foreach (var pedidoRequest in pedidos)
        {
            if (pedidoRequest.Produtos == null || !pedidoRequest.Produtos.Any())
                continue;

            var pedido = PedidoMapper.MapToEntity(pedidoRequest);
            var caixas = _empacotamentoService.Empacotar(pedido);
            var response = PedidoMapper.MapToResponse(caixas);

            responses.Add(response);
        }

        return Ok(responses);
    }
}
