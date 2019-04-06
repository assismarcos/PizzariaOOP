using PizzariaOOP.Core.Dominio.Sabor;

namespace PizzariaOOP.Core.Dominio.Pizza
{
    public class PizzaGrande : PizzaBase
    {
        public PizzaGrande(SaborBase sabor) : base(sabor)
        {
        }

        public override decimal Valor() => base.Valor() + 40.00m;

        public override int TempoPreparo() => base.TempoPreparo() + 25;

        public override string Tamanho() => ConstantesPizza.TamanhoGrande;
    }
}
