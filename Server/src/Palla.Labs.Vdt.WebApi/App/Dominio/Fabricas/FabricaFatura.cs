using System;
using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaFatura
    {
        public virtual Fatura Criar(Guid siteId, DateTime dateTime, decimal valorPorEquipamento, decimal valorPorUsuario,
            IEnumerable<Equipamento> equipamentos, IEnumerable<Usuario> usuarios)
        {
            return Criar(Guid.NewGuid(), siteId, dateTime, valorPorEquipamento, valorPorUsuario,
                equipamentos, usuarios);
        }

        public virtual Fatura Criar(Guid id, Guid siteId, DateTime dateTime, decimal valorPorEquipamento, decimal valorPorUsuario,
            IEnumerable<Equipamento> equipamentos, IEnumerable<Usuario> usuarios)
        {
            var quantidadeEquipamentos = equipamentos.Count();
            var quantidadeUsuarios = usuarios.Count();
            var valorEquipamento = valorPorEquipamento * quantidadeEquipamentos;
            var valorUsuario = valorPorUsuario * quantidadeUsuarios;
            const int descontos = 0;
            var total = (valorUsuario + valorEquipamento) - descontos;
            return new Fatura(id, siteId, dateTime.Month, dateTime.Year, quantidadeEquipamentos, valorEquipamento, quantidadeUsuarios, valorEquipamento,
                descontos, total);
        }
    }
}