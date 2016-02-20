namespace Palla.Labs.Vdt.App.Dominio.Excecoes
{
    public class RecursoNaoEncontrado : ExcecaoBase
    {
        public RecursoNaoEncontrado(string mensagem)
            : base(mensagem, mensagem)
        {
        }
    }
}