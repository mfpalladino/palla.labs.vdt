using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class LocalizadorEquipamento
    {
        private readonly RepositorioEquipamentos _repositorioEquipamentos;
        private readonly FabricaEquipamentoDto _fabricaEquipamentoDto;

        public LocalizadorEquipamento(RepositorioEquipamentos repositorioEquipamentos, FabricaEquipamentoDto fabricaEquipamentoDto)
        {
            _repositorioEquipamentos = repositorioEquipamentos;
            _fabricaEquipamentoDto = fabricaEquipamentoDto;
        }

        public EquipamentoDto Localizar(string id)
        {
            Validar(id);
            return _fabricaEquipamentoDto.Criar(_repositorioEquipamentos.BuscarPorId(new Guid(id)));
        }

        public IEnumerable<EquipamentoDto> Localizar()
        {
            return _fabricaEquipamentoDto.Criar(_repositorioEquipamentos.Buscar());
        }

        private void Validar(string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de equipamento informado n�o � v�lido.");

            if (_repositorioEquipamentos.BuscarPorId(new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Equipamento n�o encontrado");
        }
    }
}