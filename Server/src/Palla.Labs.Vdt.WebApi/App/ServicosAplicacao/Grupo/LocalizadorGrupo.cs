using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class LocalizadorGrupo
    {
        private readonly RepositorioGrupos _repositorioGrupos;
        private readonly FabricaGrupoDto _fabricaGrupoDto;

        public LocalizadorGrupo(RepositorioGrupos repositorioGrupos, FabricaGrupoDto fabricaGrupoDto)
        {
            _repositorioGrupos = repositorioGrupos;
            _fabricaGrupoDto = fabricaGrupoDto;
        }

        public GrupoDto Localizar(string id)
        {
            Validar(id);
            return _fabricaGrupoDto.Criar(_repositorioGrupos.BuscarPorId(new Guid(id)));
        }

        public IEnumerable<GrupoDto> Localizar()
        {
            return _fabricaGrupoDto.Criar(_repositorioGrupos.Buscar());
        }

        private void Validar(string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de grupo informado não é válido.");

            if (_repositorioGrupos.BuscarPorId(new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Grupo não encontrado");
        }
    }
}