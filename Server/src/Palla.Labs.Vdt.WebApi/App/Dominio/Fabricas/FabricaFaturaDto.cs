using System;
using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaFaturaDto
    {
        public virtual IEnumerable<FaturaDto> Criar(Site site, IEnumerable<Fatura> faturas)
        {
            return faturas.Select(x=> Criar(site, x)).OrderByDescending(x => x.Ano).ThenByDescending(x => x.Mes);
        }

        public virtual FaturaDto Criar(Site site, Fatura fatura)
        {
            return new FaturaDto
            {
                Id = fatura.Id, 
                Ano = fatura.Ano, 
                Mes = fatura.Mes, 
                QuantidadeEquipamentos = fatura.QuantidadeEquipamentos,
                QuantidadeUsuarios = fatura.QuantidadeUsuarios, 
                ValorPorEquipamento = fatura.ValorPorEquipamento, 
                ValorPorUsuario = fatura.ValorPorUsuario,
                TotalPorEquipamento = fatura.TotalPorEquipamento,
                TotalPorUsuario = fatura.TotalPorUsuario,
                Descontos = fatura.Descontos, 
                Total = fatura.Total,
                PagamentoLiberadoAPartirDe = new DateTime(fatura.Ano, fatura.Mes, site.DiaVencimento-10)
            };
        }
    }
}