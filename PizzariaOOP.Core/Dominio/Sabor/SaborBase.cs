using PizzariaOOP.Core.Interfaces;

namespace PizzariaOOP.Core.Dominio.Sabor
{
    public static class ConstantesSabor
    {
        public const string Calabresa = "Calabresa";
        public const string Marguerita = "Marguerita";
        public const string Portuguesa = "Portuguesa";
    }

    public abstract class SaborBase : ISabor
    {
        public virtual int TempoPreparo() => 0;
    }
}
