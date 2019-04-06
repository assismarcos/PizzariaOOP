using PizzariaOOP.Core.Dominio.Sabor;
using PizzariaOOP.Core.Interfaces;

namespace PizzariaOOP.Core.Dominio.Pizza
{
    public static class ConstantesPizza
    {
        public const string TamanhoPequeno = "Pequena";
        public const string TamanhoMedio = "Media";
        public const string TamanhoGrande = "Grande";
    }

    public abstract class PizzaBase : IPizza
    {
        protected SaborBase Sabor;

        protected PizzaBase(SaborBase sabor)
        {
            Sabor = sabor;
        }

        public virtual decimal Valor() => 0.0m;

        public virtual int TempoPreparo() => 0;

        public virtual string Tamanho() => ConstantesPizza.TamanhoPequeno;

        public virtual SaborBase SaborEscolhido() => this.Sabor;
    }
}
