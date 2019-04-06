using PizzariaOOP.Core.Interfaces;

namespace PizzariaOOP.Core.Dominio.Personalizacao
{
    public static class ConstantesPersonalizacao
    {
        public const string ExtraBacon = "extra bacon";
        public const string SemCebola = "sem cebola";
        public const string BordaRecheada = "borda recheada";
    }

    public abstract class PersonalizacaoBase : IPersonalizacao
    {
        public virtual decimal Valor() => 0.0m;

        public virtual int TempoAdicionalPreparo() => 0;
    }
}
