namespace Palla.Labs.Vdt.App.ServicosAplicacao.Dtos
{
    public class ResultadoErro
    {
        public ResultadoErro(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; set; }

        public static ResultadoErro CriarErroNaoEsperado()
        {
            return new ResultadoErro("Erro não esperado");
        }
    }
}