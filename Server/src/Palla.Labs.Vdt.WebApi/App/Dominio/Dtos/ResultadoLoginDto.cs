namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class ResultadoLoginDto
    {
        public string Token { get; set; }
        public PermissoesDto Permissoes { get; set; }
    }
}