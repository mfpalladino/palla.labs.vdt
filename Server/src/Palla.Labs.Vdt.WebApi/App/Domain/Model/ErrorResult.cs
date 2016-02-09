namespace Palla.Labs.Vdt.App.Domain.Model
{
    public class ErrorResult
    {
        public string Message { get; set; }

        public ErrorResult(string message)
        {
            Message = message;
        }

        public static ErrorResult CreateNotUnmappedError()
        {
            return new ErrorResult("Erro não esperado");
        }
    }
}