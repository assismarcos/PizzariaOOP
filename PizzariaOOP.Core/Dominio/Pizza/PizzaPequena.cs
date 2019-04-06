using PizzariaOOP.Core.Dominio.Sabor;

namespace PizzariaOOP.Core.Dominio.Pizza
{
    public class PizzaPequena : PizzaBase
    {
        public PizzaPequena(SaborBase sabor) : base(sabor)
        {
        }

        public override decimal Valor() => base.Valor() + 20.00m;

        public override int TempoPreparo() => base.TempoPreparo() + 15;
    }
}
