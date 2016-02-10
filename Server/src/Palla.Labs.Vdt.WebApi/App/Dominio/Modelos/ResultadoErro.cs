namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class ResultadoErro
    {
        public string Message { get; set; }

        public ResultadoErro(string message)
        {
            Message = message;
        }

        public static ResultadoErro CreateNotUnmappedError()
        {
            return new ResultadoErro("Erro não esperado");
        }
    }
}