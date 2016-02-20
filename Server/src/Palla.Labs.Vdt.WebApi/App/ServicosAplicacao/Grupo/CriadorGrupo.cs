using AutoMapper;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class CriadorGrupo
    {
        private readonly RepositorioGrupos _repositorioGrupos;
        private readonly IMapper _mapper;

        public CriadorGrupo(RepositorioGrupos repositorioGrupos, IMapper mapper)
        {
            _repositorioGrupos = repositorioGrupos;
            _mapper = mapper;
        }

        public Dominio.Modelos.Grupo Criar(Grupo grupo)
        {
            var grupoParaSalvar = _mapper.Map<Dominio.Modelos.Grupo>(grupo);
            _repositorioGrupos.Inserir(grupoParaSalvar);
            return grupoParaSalvar;
        }
    }
}