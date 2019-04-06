namespace PizzariaOOP.Core.Dominio.Personalizacao
{
    public class ExtraBacon : PersonalizacaoBase
    {
        public override decimal Valor() => 3.00m;

        public override string ToString() => ConstantesPersonalizacao.ExtraBacon;
    }
}
