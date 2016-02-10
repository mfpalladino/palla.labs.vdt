using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.WebApi.Testes.Fabricas;

namespace Palla.Labs.Vdt.WebApi.Testes.Integracao.Repositorios
{
    [TestFixture]
    public class RepositorioEquipamentoDeve
    {
        [Test]
        public void LidarCorretamenteComHierarquiaDeEquipamentos()
        {
            var leitorConfiguracoes = new ConfigBancoDadosVariavelAmbienteTestes();
            var repositorio = new RepositorioEquipamentos(new MongoClient(leitorConfiguracoes.StringConexao), leitorConfiguracoes);

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

                repositorio.ListarPorId(extintor.Id).Tipo.Should().Be(TipoEquipamento.Extintor);
                repositorio.ListarPorId(mangueira.Id).Tipo.Should().Be(TipoEquipamento.Mangueira);
                repositorio.ListarPorId(sistemaContraIncendioEmCoifa.Id).Tipo.Should().Be(TipoEquipamento.SistemaContraIncendioEmCoifa);
                repositorio.ListarPorId(centralAlarme.Id).Tipo.Should().Be(TipoEquipamento.CentralAlarme);
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