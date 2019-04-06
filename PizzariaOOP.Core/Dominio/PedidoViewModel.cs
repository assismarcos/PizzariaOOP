using System.Collections.Generic;

namespace PizzariaOOP.Core.Dominio
{
    public class PedidoViewModel
    {
        public string Tamanho { get; set; }

        public string Sabor { get; set; }

        public List<string> Personalizacoes { get; set; }
    }
}
