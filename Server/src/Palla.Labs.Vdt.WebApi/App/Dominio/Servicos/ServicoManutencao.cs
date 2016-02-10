using System;
using System.Linq;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

namespace Palla.Labs.Vdt.App.Dominio.Servicos
{
    public class ServicoManutencao
    {
        private readonly RepositorioEquipamentos _repositorioEquipamentos;

        public ServicoManutencao(RepositorioEquipamentos repositorioEquipamentos)
        {
            _repositorioEquipamentos = repositorioEquipamentos;
        }

        public void Inserir(Guid idEquipamento, string parte)
        {
            var equipamento = _repositorioEquipamentos.ListarPorId(idEquipamento);

            if (equipamento.ParametrosVencimento.Partes.Select(x => x.Nome).All(x => x != parte))
                throw new Exception("A parte informada não faz parte do equipamento.");

            var manutencao = new Manutencao(DateTime.Now, parte);

            _repositorioEquipamentos.InserirManutencao(equipamento, manutencao);
        }
    }
}