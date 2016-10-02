using System;

namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class FaturaDto : DtoBase<Guid>
    {
        public int Mes { get; set; }

        public int Ano { get; set; }

        public int QuantidadeEquipamentos { get; set; }

        public decimal ValorPorEquipamento { get; set; }

        public int QuantidadeUsuarios { get; set; }

        public decimal ValorPorUsuario { get; set; }

        public decimal Descontos { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPorEquipamento { get; set; }

        public decimal TotalPorUsuario { get; set; }

        public DateTime PagamentoLiberadoAPartirDe { get; set; }

        public string PagamentoLiberadoAPartirDeComoString
        {
            get { return PagamentoLiberadoAPartirDe.ToString("d"); }
        }

        public string MesAnoComoString
        {
            get { return string.Format("{0}/{1}", Mes, Ano); }
        }

        public string TotalComoString
        {
            get { return Total.ToString("C"); }
        }

        public string ValorPorEquipamentoComoString
        {
            get { return ValorPorEquipamento.ToString("N2"); }
        }

        public string TotalPorEquipamentoComoString
        {
            get { return TotalPorEquipamento.ToString("C"); }
        }

        public string ValorPorUsuarioComoString
        {
            get { return ValorPorUsuario.ToString("N2"); }
        }

        public string TotalPorUsuarioComoString
        {
            get { return TotalPorUsuario.ToString("C"); }
        }
    }
}