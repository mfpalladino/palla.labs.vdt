namespace Palla.Labs.Vdt.App.Dominio.Excecoes
{
    public class FormatoInvalido : ExcecaoBase
    {
        public FormatoInvalido(string mensagem)
            : base(mensagem, mensagem)
        {
        }
    }
}