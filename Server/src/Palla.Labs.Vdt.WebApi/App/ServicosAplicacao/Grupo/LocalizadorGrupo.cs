using System;
using System.Collections.Generic;
using AutoMapper;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class LocalizadorGrupo
    {
        private readonly RepositorioGrupos _repositorioGrupos;
        private readonly IMapper _mapper;

        public LocalizadorGrupo(RepositorioGrupos repositorioGrupos, IMapper mapper)
        {
            _repositorioGrupos = repositorioGrupos;
            _mapper = mapper;
        }

        public Grupo Localizar(string id)
        {
            Validar(id);
            return _mapper.Map<Grupo>(_repositorioGrupos.ListarPorId(new Guid(id)));
        }

        public IEnumerable<Grupo> Localizar()
        {
            return _mapper.Map<IEnumerable<Grupo>>(_repositorioGrupos.ListarTodos());
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