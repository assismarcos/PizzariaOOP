using PizzariaOOP.Core.Dominio.Sabor;

namespace PizzariaOOP.Core.Dominio.Pizza
{
    public class PizzaMedia : PizzaBase
    {
        public PizzaMedia(SaborBase sabor) : base(sabor)
        {
        }

        public override decimal Valor() => base.Valor() + 30.00m;

        public override int TempoPreparo() => base.TempoPreparo() + 20;

        public override string Tamanho() => ConstantesPizza.TamanhoMedio;
    }
}
