using System;
using System.Linq;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class CriadorManutencao
    {
        private readonly RepositorioEquipamentos _repositorioEquipamentos;

        public CriadorManutencao(RepositorioEquipamentos repositorioEquipamentos)
        {
            _repositorioEquipamentos = repositorioEquipamentos;
        }

        public void Criar(Guid idEquipamento, string parte)
        {
            var equipamento = _repositorioEquipamentos.BuscarPorId(idEquipamento);

            if (equipamento.ParametrosManutencao.Partes.Select(x => x.Nome).All(x => x != parte))
                throw new Exception("A parte informada não faz parte do equipamento.");

            var manutencao = new Dominio.Modelos.Manutencao(DateTime.Now, parte);

            _repositorioEquipamentos.InserirManutencao(equipamento, manutencao);
        }
    }
}