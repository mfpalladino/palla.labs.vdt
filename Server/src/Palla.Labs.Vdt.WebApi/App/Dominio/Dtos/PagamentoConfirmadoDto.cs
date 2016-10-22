namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class PagamentoConfirmadoDto
    {
        public string Token { get; set; }
        public string PagamentoId { get; set; }
        public string PagadorId { get; set; }
    }
}