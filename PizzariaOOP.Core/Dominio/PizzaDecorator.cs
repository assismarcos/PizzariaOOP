using System.Collections.Generic;
using System.Linq;
using PizzariaOOP.Core.Dominio.Pizza;
using PizzariaOOP.Core.Interfaces;

namespace PizzariaOOP.Core.Dominio
{
    public class PizzaDecorator : PizzaBase
    {
        private readonly PizzaBase _pizza;
        private readonly IList<IPersonalizacao> _personalizacoes;

        public PizzaDecorator(PizzaBase pizza) : base(pizza.SaborEscolhido())
        {
            _pizza = pizza;
            _personalizacoes = new List<IPersonalizacao>();
        }

        public static PizzaDecorator Criar(string tamanho, string sabor)
        {
            switch (tamanho)
            {
                case ConstantesPizza.TamanhoPequeno:
                    return new PizzaDecorator(new PizzaPequena(ServicoPizza.Sabores[sabor]));
                case ConstantesPizza.TamanhoMedio:
                    return new PizzaDecorator(new PizzaMedia(ServicoPizza.Sabores[sabor]));
                default:
                    return new PizzaDecorator(new PizzaGrande(ServicoPizza.Sabores[sabor]));
            }
        }

        public void AdicionarPersonalizacao(IPersonalizacao personalizacao)
        {
            if (personalizacao == null)
            {
                return;
            }
            _personalizacoes.Add(personalizacao);
        }

        public override decimal Valor() => _pizza.Valor();

        public decimal ValorTotal()
        {
            return _pizza.Valor() + _personalizacoes.Sum(x => x.Valor());
        }

        public int TempoTotalPreparo()
        {
            return _pizza.TempoPreparo() + _personalizacoes.Sum(x => x.TempoAdicionalPreparo()) + Sabor.TempoPreparo();
        }

        public IEnumerable<object> DetalhesPersonalizacoes()
        {
            foreach (var item in _personalizacoes)
            {
                yield return new {Personalizacao = item.ToString(), Valor = item.Valor()};
            }
        }

        public string Personalizacoes()
        {
            return string.Join(", ", _personalizacoes.Select(x => x.ToString()));
        }

        public override string Tamanho() => _pizza.Tamanho();

        public new string SaborEscolhido() => Sabor.ToString();
    }
}
