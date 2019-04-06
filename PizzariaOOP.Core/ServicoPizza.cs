using System.Collections.Generic;
using PizzariaOOP.Core.Dominio;
using PizzariaOOP.Core.Dominio.Personalizacao;
using PizzariaOOP.Core.Dominio.Pizza;
using PizzariaOOP.Core.Dominio.Sabor;
using PizzariaOOP.Core.Interfaces;

namespace PizzariaOOP.Core
{
    public class ServicoPizza : IServicoPizza
    {
        // As listas/tipos abaixo poderiam ser disponibilizadas em um banco de dados, caso fossem maiores e dinâmicas,
        // para isso seria necessário utilizar um repositório ao invés das listas estáticas
        public static readonly Dictionary<string, PizzaBase> Tamanhos = new Dictionary<string, PizzaBase>
        {
            // Como não temos interesse em saber qual é o sabor escolhido neste ponto e sim apenas o valor e tempo de prepado
            // é cabível informar o sabor = null no construtor de cada uma das pizzas
            {ConstantesPizza.TamanhoPequeno, new PizzaPequena(null)},
            {ConstantesPizza.TamanhoMedio, new PizzaMedia(null)},
            {ConstantesPizza.TamanhoGrande, new PizzaGrande(null)}
        };

        public static readonly Dictionary<string, SaborBase> Sabores = new Dictionary<string, SaborBase>
        {
            {ConstantesSabor.Calabresa, new SaborCalabresa()},
            {ConstantesSabor.Marguerita, new SaborMarguerita()},
            {ConstantesSabor.Portuguesa, new SaborPortuguesa()}
        };

        public static readonly Dictionary<string, PersonalizacaoBase> Personalizacoes = new Dictionary<string, PersonalizacaoBase>()
        {
            {ConstantesPersonalizacao.ExtraBacon, new ExtraBacon()},
            {ConstantesPersonalizacao.SemCebola, new SemCebola()},
            {ConstantesPersonalizacao.BordaRecheada, new BordaRecheada()}
        };

        public RespostaApi BuscarTamanhos()
        {
            var result = new List<object>();
            foreach (var item in Tamanhos)
            {
                result.Add(new
                {
                    tamanho = item.Key,
                    valor = item.Value.Valor(),
                    tempoAdicionalPreparoEmMinutos = item.Value.TempoPreparo()
                });
            }

            return new RespostaApi(result);
        }

        public RespostaApi BuscarSabores()
        {
            var result = new List<object>();
            foreach (var item in Sabores)
            {
                result.Add(new
                {
                    sabor = item.Key,
                    tempoAdicionalPreparoEmMinutos = item.Value.TempoPreparo()
                });
            }
            return new RespostaApi(result);
        }

        public RespostaApi BuscarPersonalizacoes()
        {
            var result = new List<object>();
            foreach (var item in Personalizacoes)
            {
                result.Add(new
                {
                    personalizacao = item.Key,
                    valor = item.Value.Valor(),
                    tempoAdicionalPreparoEmMinutos = item.Value.TempoAdicionalPreparo()
                });
            }
            return new RespostaApi(result);
        }
    }
}
