namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class ResultadoLogin
    {
        public ResultadoLogin(string token, Permissoes permissoes)
        {
            Token = token;
            Permissoes = permissoes;
        }

        public string Token { get; private set; }
        public Permissoes Permissoes { get; private set; }
    }
}