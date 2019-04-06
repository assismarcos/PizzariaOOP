using PizzariaOOP.Core.Dominio;
using PizzariaOOP.Core.Dominio.Pizza;
using PizzariaOOP.Core.Dominio.Sabor;
using Xunit;

namespace PizzariaOOP.Tests
{
    public class PizzaDecoratorSaborTests
    {
        [Fact]
        public void DeveCriarUmaPizzaSaborCalabresa()
        {
            var pizza = new PizzaDecorator(new PizzaPequena(new SaborCalabresa()));
            Assert.Equal(ConstantesSabor.Calabresa, pizza.SaborEscolhido());
        }

        [Fact]
        public void DeveCriarUmaPizzaSaborMarguerita()
        {
            var pizza = new PizzaDecorator(new PizzaPequena(new SaborMarguerita()));
            Assert.Equal(ConstantesSabor.Marguerita, pizza.SaborEscolhido());
        }

        [Fact]
        public void DeveCriarUmaPizzaSaborPortuguesa()
        {
            var pizza = new PizzaDecorator(new PizzaPequena(new SaborPortuguesa()));
            Assert.Equal(ConstantesSabor.Portuguesa, pizza.SaborEscolhido());
        }
    }
}
