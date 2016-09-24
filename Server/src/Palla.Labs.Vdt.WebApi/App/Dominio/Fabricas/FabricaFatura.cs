using System;
using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class FabricaFatura
    {
        private readonly RepositorioEquipamentos _repositorioEquipamentos;
        private readonly RepositorioUsuarios _repositorioUsuarios;
        private readonly RepositorioFaturas _repositorioFaturas;

        public FabricaFatura(RepositorioEquipamentos repositorioEquipamentos,
            RepositorioUsuarios repositorioUsuarios,
            RepositorioFaturas repositorioFaturas)
        {
            _repositorioEquipamentos = repositorioEquipamentos;
            _repositorioUsuarios = repositorioUsuarios;
            _repositorioFaturas = repositorioFaturas;
        }

        public virtual Fatura CriarAtual(Guid siteId)
        {
            var ultimaFatura = _repositorioFaturas.BuscarUltima(siteId);

            var dataFatura = DateTime.Now;
            if (ultimaFatura != null)
                dataFatura = new DateTime(ultimaFatura.Ano, ultimaFatura.Mes, 1).AddMonths(1);

            var equipamentos = _repositorioEquipamentos.Buscar(siteId);
            var usuarios = _repositorioUsuarios.Buscar(siteId);

            const decimal valorPorEquipamento = 1;
            const decimal valorPorUsuario = 2;

            return Criar(siteId, dataFatura, valorPorEquipamento, valorPorUsuario, equipamentos, usuarios);
        }

        public virtual Fatura Criar(Guid siteId, FaturaDto faturaDto)
        {
            return Criar(Guid.NewGuid(), 
                siteId, 
                new DateTime(faturaDto.Ano, faturaDto.Mes, 1),
                faturaDto.ValorPorEquipamento,
                faturaDto.ValorPorUsuario,
                faturaDto.QuantidadeEquipamentos,
                faturaDto.QuantidadeUsuarios,
                faturaDto.Descontos,
                faturaDto.Total);
        }

        public virtual Fatura Criar(Guid siteId, DateTime dateTime, decimal valorPorEquipamento, decimal valorPorUsuario,
            IEnumerable<Equipamento> equipamentos, IEnumerable<Usuario> usuarios)
        {
            return Criar(Guid.NewGuid(), siteId, dateTime, valorPorEquipamento, valorPorUsuario,
                equipamentos, usuarios);
        }

        public virtual Fatura Criar(Guid id, Guid siteId, DateTime dateTime, decimal valorPorEquipamento, decimal valorPorUsuario,
            IEnumerable<Equipamento> equipamentos, IEnumerable<Usuario> usuarios)
        {
            const int descontos = 0;
            var quantidadeEquipamentos = equipamentos.Count();
            var quantidadeUsuarios = usuarios.Count();
            var valorEquipamento = valorPorEquipamento * quantidadeEquipamentos;
            var valorUsuario = valorPorUsuario * quantidadeUsuarios;

            var total = (valorUsuario + valorEquipamento) - descontos;
            return Criar(id, siteId, dateTime, valorPorEquipamento, valorPorUsuario, quantidadeEquipamentos, quantidadeUsuarios, descontos, total);
        }

        public virtual Fatura Criar(Guid id, Guid siteId, DateTime dateTime, decimal valorPorEquipamento, decimal valorPorUsuario,
            int quantidadeEquipamentos, int quantidadeUsuarios, decimal descontos, decimal total)
        {
            return new Fatura(id, siteId, dateTime.Month, dateTime.Year, quantidadeEquipamentos, valorPorEquipamento, quantidadeUsuarios, valorPorUsuario,
                descontos, total);
        }
    }
}