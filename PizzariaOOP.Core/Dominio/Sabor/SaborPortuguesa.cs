namespace PizzariaOOP.Core.Dominio.Sabor
{
    public class SaborPortuguesa : SaborBase
    {
        public override int TempoPreparo() => base.TempoPreparo() + 5;

        public override string ToString() => ConstantesSabor.Portuguesa;
    }
}
