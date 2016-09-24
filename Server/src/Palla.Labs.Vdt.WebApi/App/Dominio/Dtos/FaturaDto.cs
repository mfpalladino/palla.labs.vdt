using System;
using System.Globalization;

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

        public DateTime Data
        {
            get { return new DateTime(Ano, Mes, DateTime.Now.Day); }
        }

        public string DataComoString
        {
            get { return Data.Date.ToString("d"); }
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
            get { return (QuantidadeEquipamentos * ValorPorEquipamento).ToString("C"); }
        }

        public string ValorPorUsuarioComoString
        {
            get { return ValorPorUsuario.ToString("N2"); }
        }

        public string TotalPorUsuarioComoString
        {
            get { return (QuantidadeUsuarios * ValorPorUsuario).ToString("C"); }
        }
    }
}