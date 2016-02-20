using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class CriadorGrupo
    {
        private readonly RepositorioGrupos _repositorioGrupos;

        public CriadorGrupo(RepositorioGrupos repositorioGrupos)
        {
            _repositorioGrupos = repositorioGrupos;
        }

        public Dominio.Modelos.Grupo Criar(Grupo grupo)
        {
            var grupoParaSalvar = new Dominio.Fabricas.ConstrutorGrupo(grupo).Construir();
            _repositorioGrupos.Inserir(grupoParaSalvar);
            return grupoParaSalvar;
        }
    }
}