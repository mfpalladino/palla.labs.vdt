using System;
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

        public ModificadorGrupo(RepositorioGrupos repositorioGrupos)
        {
            _repositorioGrupos = repositorioGrupos;
        }

        public void Modificar(string id, Grupo grupo)
        {
            Validar(id);
            _repositorioGrupos.Editar(new Dominio.Fabricas.ConstrutorGrupo(grupo).ComId(new Guid(id)).Construir());
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