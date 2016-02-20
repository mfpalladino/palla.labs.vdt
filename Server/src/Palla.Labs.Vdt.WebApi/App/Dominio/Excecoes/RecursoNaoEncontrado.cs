namespace Palla.Labs.Vdt.App.Dominio.Excecoes
{
    public class RecursoNaoEncontrado : ExcecaoBase
    {
        public RecursoNaoEncontrado() //usado apenas para testes
        {
            
        }
        
        public RecursoNaoEncontrado(string mensagem)
            : base(mensagem, mensagem)
        {
        }
    }
}