using PizzariaOOP.Core.Dominio;
using PizzariaOOP.Core.Dominio.Pizza;
using PizzariaOOP.Core.Dominio.Sabor;
using Xunit;

namespace PizzariaOOP.Tests
{
    public class PizzaDecoratorTamanhoTests
    {
        [Fact]
        public void DeveCriarUmaPizzaPequena()
        {
            var pizza = new PizzaDecorator(new PizzaPequena(new SaborCalabresa()));

            Assert.Equal(ConstantesPizza.TamanhoPequeno, pizza.Tamanho());
        }

        [Fact]
        public void DeveCriarUmaPizzaMedia()
        {
            var pizza = new PizzaDecorator(new PizzaMedia(new SaborCalabresa()));

            Assert.Equal(ConstantesPizza.TamanhoMedio, pizza.Tamanho());
        }

        [Fact]
        public void DeveCriarUmaPizzaGrande()
        {
            var pizza = new PizzaDecorator(new PizzaGrande(new SaborCalabresa()));

            Assert.Equal(ConstantesPizza.TamanhoGrande, pizza.Tamanho());
        }
    }
}