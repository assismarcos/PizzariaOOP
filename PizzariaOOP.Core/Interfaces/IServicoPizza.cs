using PizzariaOOP.Core.Dominio;

namespace PizzariaOOP.Core.Interfaces
{
    public interface IServicoPizza
    {
        RespostaApi BuscarTamanhos();

        RespostaApi BuscarSabores();

        RespostaApi BuscarPersonalizacoes();
    }
}
