using PizzariaOOP.Core.Dominio;

namespace PizzariaOOP.Core.Interfaces
{
    public interface IServicoPedido
    {
        RespostaApi BuscarPorId(int id);

        RespostaApi Inserir(PedidoViewModel pedidoViewModel);
    }
}
