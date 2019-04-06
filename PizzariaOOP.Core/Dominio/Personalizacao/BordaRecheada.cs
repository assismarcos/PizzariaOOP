namespace PizzariaOOP.Core.Dominio.Personalizacao
{
    public class BordaRecheada : PersonalizacaoBase
    {
        public override decimal Valor() => 5.0m;

        public override int TempoAdicionalPreparo() => 5;

        public override string ToString() => ConstantesPersonalizacao.BordaRecheada;
    }
}
