using System;
using AutoMapper;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ModificadorGrupo
    {
        private readonly RepositorioGrupos _repositorioGrupos;
        private readonly IMapper _mapper;

        public ModificadorGrupo(RepositorioGrupos repositorioGrupos, IMapper mapper)
        {
            _repositorioGrupos = repositorioGrupos;
            _mapper = mapper;
        }

        public void Modificar(string id, Grupo grupo)
        {
            Validar(id);

            grupo.Id = new Guid(id);

            _repositorioGrupos.Editar(_mapper.Map<Dominio.Modelos.Grupo>(grupo));
        }

        private void Validar(string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de grupo informado não é válido.");

            if (_repositorioGrupos.ListarPorId(new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Grupo não encontrado");
        }
    }
}