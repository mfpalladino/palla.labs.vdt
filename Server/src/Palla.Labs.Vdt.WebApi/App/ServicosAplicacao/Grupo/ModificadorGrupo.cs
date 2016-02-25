using System;
using AutoMapper;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.AutoMapper;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ModificadorGrupo
    {
        private readonly RepositorioGrupos _repositorioGrupos;
        private readonly IMapper _mapeador;

        public ModificadorGrupo(RepositorioGrupos repositorioGrupos, IMapper mapeador)
        {
            _repositorioGrupos = repositorioGrupos;
            _mapeador = mapeador;
        }

        public void Modificar(string id, GrupoDto grupoDto)
        {
            Validar(id);
            _repositorioGrupos.Editar(_mapeador.ParaEntidade<Grupo, GrupoDto>(id.ParaGuid(), grupoDto));
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