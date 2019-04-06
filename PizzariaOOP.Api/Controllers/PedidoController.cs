using Microsoft.AspNetCore.Mvc;
using PizzariaOOP.Core.Dominio;
using PizzariaOOP.Core.Interfaces;

namespace PizzariaOOP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IServicoPedido _servico;
        public PedidoController(IServicoPedido servico)
        {
            _servico = servico;
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(int id)
        {
            var retorno = _servico.BuscarPorId(id);
            if (retorno == null)
            {
                return NotFound();
            }
            return Ok(retorno.Dados);
        }


        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] PedidoViewModel pedido)
        {
            var retorno = _servico.Inserir(pedido);
            if (retorno.Dados == null)
            {
                return BadRequest(retorno);
            }

            return Ok(retorno);
        }
    }
}
