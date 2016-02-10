using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Modelos.Equipamento;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.WebApi.Testes.Fabricas;

namespace Palla.Labs.Vdt.WebApi.Testes.Integracao
{
    [TestFixture]
    public class RepositorioEquipamentoDeve
    {
        [Test]
        public void LidarCorretamenteComHierarquiaDeEquipamentos()
        {
            var repositorio = new RepositorioEquipamentos();

            Extintor extintor = null;
            Mangueira mangueira = null;
            SistemaContraIncendioEmCoifa sistemaContraIncendioEmCoifa = null;
            CentralAlarme centralAlarme = null;

            try
            {
                extintor = new ConstrutorExtintor().Construir();
                repositorio.Inserir(extintor);

                mangueira = new ConstrutorMangueira().Construir();
                repositorio.Inserir(mangueira);

                sistemaContraIncendioEmCoifa = new ConstrutorSistemaContraIncendioEmCoifa().Construir();
                repositorio.Inserir(sistemaContraIncendioEmCoifa);

                centralAlarme = new ConstrutorCentralAlarme().Construir();
                repositorio.Inserir(centralAlarme);

                var resultadoPesquisa = repositorio.ListarTodos().ToList();

                resultadoPesquisa.First(x => x.Id == extintor.Id).Tipo.Should().Be(TipoEquipamento.Extintor);
                resultadoPesquisa.First(x => x.Id == mangueira.Id).Tipo.Should().Be(TipoEquipamento.Mangueira);
                resultadoPesquisa.First(x => x.Id == sistemaContraIncendioEmCoifa.Id).Tipo.Should().Be(TipoEquipamento.SistemaContraIncendioEmCoifa);
                resultadoPesquisa.First(x => x.Id == centralAlarme.Id).Tipo.Should().Be(TipoEquipamento.CentralAlarme);
            }
            finally
            {
                if (extintor != null)
                    repositorio.Remover(extintor.Id);

                if (mangueira != null)
                    repositorio.Remover(mangueira.Id);

                if (sistemaContraIncendioEmCoifa != null)
                    repositorio.Remover(sistemaContraIncendioEmCoifa.Id);

                if (centralAlarme != null)
                    repositorio.Remover(centralAlarme.Id);
            }
        }
    }
}