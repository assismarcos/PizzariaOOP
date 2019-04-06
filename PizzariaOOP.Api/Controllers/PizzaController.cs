using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzariaOOP.Core.Interfaces;

namespace PizzariaOOP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IServicoPizza _servico;

        public PizzaController(IServicoPizza servico)
        {
            _servico = servico;
        }

        [HttpGet("tamanhos")]
        public ActionResult<IEnumerable<string>> Tamanhos()
        {
            return Ok(_servico.BuscarTamanhos());
        }

        [HttpGet("sabores")]
        public ActionResult<IEnumerable<string>> Sabores()
        {
            return Ok(_servico.BuscarSabores());
        }

        [HttpGet("personalizacoes")]
        public ActionResult<IEnumerable<string>> Personalizacoes()
        {
            return Ok(_servico.BuscarPersonalizacoes());
        }

    }
}
