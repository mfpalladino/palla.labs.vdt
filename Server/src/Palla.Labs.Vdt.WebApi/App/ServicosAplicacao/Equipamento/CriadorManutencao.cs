using System;
using System.Linq;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class CriadorManutencao
    {
        private readonly RepositorioEquipamentos _repositorioEquipamentos;
        private readonly FabricaManutencao _fabricaManutencao;

        public CriadorManutencao(RepositorioEquipamentos repositorioEquipamentos, FabricaManutencao fabricaManutencao)
        {
            _repositorioEquipamentos = repositorioEquipamentos;
            _fabricaManutencao = fabricaManutencao;
        }

        public Manutencao Criar(string idEquipamento, ManutencaoDto manutencaoDto)
        {
            if (!idEquipamento.GuidValido())
                throw new FormatoInvalido("O identificador do equipamento deve ser informado.");

            if (String.IsNullOrWhiteSpace(manutencaoDto.Parte))
                throw new FormatoInvalido("A parte do equipamento deve ser informada.");

            if (manutencaoDto.Data < 0)
                throw new FormatoInvalido("A data da manutenção da parte do equipamento não é válida.");

            var equipamento = _repositorioEquipamentos.BuscarPorId(idEquipamento.ParaGuid());

            if (equipamento == null)
                throw new RecursoNaoEncontrado("Equipamento não encontrado.");

            if (equipamento.ParametrosManutencao.Partes.Select(x => x.Nome).All(x => x != manutencaoDto.Parte))
                throw new FormatoInvalido("A parte informada para menutenção não faz parte do equipamento especificado.");

            var manutencao = _fabricaManutencao.Criar(idEquipamento.ParaGuid(), manutencaoDto);
            _repositorioEquipamentos.InserirManutencao(equipamento, manutencao);
            return manutencao;
        }
    }
}