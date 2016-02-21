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
        private readonly IMapper _mapeador;

        public LocalizadorGrupo(RepositorioGrupos repositorioGrupos, IMapper mapeador)
        {
            _repositorioGrupos = repositorioGrupos;
            _mapeador = mapeador;
        }

        public GrupoDto Localizar(string id)
        {
            Validar(id);
            return _mapeador.Map<GrupoDto>(_repositorioGrupos.ListarPorId(new Guid(id)));
        }

        public IEnumerable<GrupoDto> Localizar()
        {
            return _mapeador.Map<IEnumerable<GrupoDto>>(_repositorioGrupos.ListarTodos());
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