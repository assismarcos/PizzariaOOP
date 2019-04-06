namespace PizzariaOOP.Core.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }

        public string Tamanho { get; set; }

        public string Sabor { get; set; }

        public string Personalizacoes { get; set; }

        public decimal ValorTotal { get; set; }

        public int TempoPreparo { get; set; }
    }
}
