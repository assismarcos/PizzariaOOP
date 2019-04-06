using PizzariaOOP.Core.Dominio;
using PizzariaOOP.Core.Dominio.Personalizacao;
using PizzariaOOP.Core.Dominio.Pizza;
using PizzariaOOP.Core.Dominio.Sabor;
using Xunit;

namespace PizzariaOOP.Tests
{
    public class PizzaDecoratorAdicionaisTests
    {
        [Fact]
        public void DeveCriarUmaPizzaMargueritaSemAdicionais()
        {
            var pizza = new PizzaDecorator(new PizzaPequena(new SaborMarguerita()));

            pizza.AdicionarPersonalizacao(null);

            Assert.Equal(string.Empty, pizza.Personalizacoes());
        }

        [Fact]
        public void DeveCriarUmaPizzaMargueritaComTodosAdicionais()
        {
            var pizza = new PizzaDecorator(new PizzaPequena(new SaborMarguerita()));

            pizza.AdicionarPersonalizacao(new BordaRecheada());
            pizza.AdicionarPersonalizacao(new ExtraBacon());
            pizza.AdicionarPersonalizacao(new SemCebola());

            Assert.NotEqual(string.Empty, pizza.Personalizacoes());
        }

        [Fact]
        public void DeveCriarUmaPizzaMargueritaComDoisAdicionais()
        {
            var pizza = new PizzaDecorator(new PizzaPequena(new SaborMarguerita()));

            pizza.AdicionarPersonalizacao(new BordaRecheada());
            pizza.AdicionarPersonalizacao(new SemCebola());

            Assert.NotEqual(string.Empty, pizza.Personalizacoes());
            Assert.Equal($"{ConstantesPersonalizacao.BordaRecheada}, {ConstantesPersonalizacao.SemCebola}", pizza.Personalizacoes());
            Assert.Equal(25, pizza.ValorTotal());
            Assert.Equal(20, pizza.TempoTotalPreparo());
            //Assert.Equal(25, pizza.Valor());
            //Assert.Equal(20, pizza.TempoPreparo());
        }

    }
}
