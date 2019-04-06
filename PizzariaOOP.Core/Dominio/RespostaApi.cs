namespace PizzariaOOP.Core.Dominio
{
    public class RespostaApi
    {
        public string Mensagem { get; }

        public object Dados { get; }

        public RespostaApi(string mensagem)
        {
            Mensagem = mensagem;
        }

        public RespostaApi(string mensagem, object dados) : this(mensagem)
        {
            Dados = dados;
        }

        public RespostaApi(object dados) : this(string.Empty)
        {
            Dados = dados;
        }
    }
}
