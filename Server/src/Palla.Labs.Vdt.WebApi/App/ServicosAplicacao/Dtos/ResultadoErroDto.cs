namespace Palla.Labs.Vdt.App.ServicosAplicacao.Dtos
{
    public class ResultadoErroDto
    {
        public ResultadoErroDto(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; set; }

        public static ResultadoErroDto CriarErroNaoEsperado()
        {
            return new ResultadoErroDto("Erro não esperado");
        }
    }
}