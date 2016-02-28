using System;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ModificadorGrupo
    {
        private readonly RepositorioGrupos _repositorioGrupos;
        private readonly FabricaGrupo _fabricaGrupo;

        public ModificadorGrupo(RepositorioGrupos repositorioGrupos, FabricaGrupo fabricaGrupo)
        {
            _repositorioGrupos = repositorioGrupos;
            _fabricaGrupo = fabricaGrupo;
        }

        public void Modificar(string id, GrupoDto grupoDto)
        {
            Validar(id);
            _repositorioGrupos.Editar(_fabricaGrupo.Criar(id.ParaGuid(), grupoDto));
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