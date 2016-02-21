namespace Palla.Labs.Vdt.App.Dominio.Excecoes
{
    public class JaExisteUmRecursoComEstasCaracteristicas : ExcecaoBase
    {
        public JaExisteUmRecursoComEstasCaracteristicas() //usado apenas para testes
        {

        }

        public JaExisteUmRecursoComEstasCaracteristicas(string mensagem)
            : base(mensagem, mensagem)
        {
        }
    }
}