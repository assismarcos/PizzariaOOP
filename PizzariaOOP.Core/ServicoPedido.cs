using System.Collections.Generic;
using System.Linq;
using PizzariaOOP.Core.Contexto;
using PizzariaOOP.Core.Dominio;
using PizzariaOOP.Core.Interfaces;

namespace PizzariaOOP.Core
{
    public class ServicoPedido : IServicoPedido
    {
        private readonly PizzariaContext _contexto;

        public ServicoPedido(PizzariaContext contexto)
        {
            _contexto = contexto;
        }

        public RespostaApi BuscarPorId(int id)
        {
            return new RespostaApi("", _contexto.Pedidos.Where(x => x.Id == id));
        }

        public RespostaApi Inserir(PedidoViewModel pedidoViewModel)
        {
            if (!ValidarTamanho(pedidoViewModel.Tamanho))
            {
                return new RespostaApi($"Tamanho inválido ou não informado: {pedidoViewModel.Tamanho}");
            }

            if (!ValidarSabor(pedidoViewModel.Sabor))
            {
                return new RespostaApi($"Sabor inválido ou não informado: {pedidoViewModel.Sabor}");
            }

            var pizza = PizzaDecorator.Criar(pedidoViewModel.Tamanho, pedidoViewModel.Sabor);
            if (pedidoViewModel.Personalizacoes?.Count > 0)
            {
                var adicionaisInvalidos = ValidarPersonalizacoes(pedidoViewModel.Personalizacoes);
                if (adicionaisInvalidos.Any())
                {
                    return new RespostaApi("Personalizações inválidas", adicionaisInvalidos);
                }
                pedidoViewModel.Personalizacoes.ForEach(x => pizza.AdicionarPersonalizacao(ServicoPizza.Personalizacoes[x]));
            }

            var pedido = new Pedido
            {
                Tamanho = pizza.Tamanho(),
                Sabor = pizza.SaborEscolhido(),
                Personalizacoes = pizza.Personalizacoes(),
                ValorTotal = pizza.ValorTotal(),
                TempoPreparo = pizza.TempoTotalPreparo()
            };
            var result = _contexto.Pedidos.Add(pedido);
            _contexto.SaveChanges();

            var resumo = new
            {
                Pedido = result.Entity.Id,
                Tamanho = pizza.Tamanho(),
                Sabor = pizza.SaborEscolhido(),
                Personalizacoes = pizza.DetalhesPersonalizacoes(),
                ValorPizza = pizza.Valor(),
                TempoPreparo = pizza.TempoTotalPreparo(),
                ValorPedido = pizza.ValorTotal()
            };
            return new RespostaApi("Pedido criado", resumo);
        }

        private bool ValidarTamanho(string tamanho) => ServicoPizza.Tamanhos.ContainsKey(tamanho ?? string.Empty);

        private bool ValidarSabor(string sabor) => ServicoPizza.Sabores.ContainsKey(sabor ?? string.Empty);

        private IEnumerable<string> ValidarPersonalizacoes(IEnumerable<string> personalizacoes)
        {
            return personalizacoes.Where(item => !ServicoPizza.Personalizacoes.ContainsKey(item));
        }
    }
}
