using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;
using Palla.Labs.Vdt.App.ServicosAplicacao.Fabricas;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class LocalizadorGrupo
    {
        private readonly RepositorioGrupos _repositorioGrupos;

        public LocalizadorGrupo(RepositorioGrupos repositorioGrupos)
        {
            _repositorioGrupos = repositorioGrupos;
        }

        public Grupo Localizar(string id)
        {
            Validar(id);
            return new ConstrutorGrupoDto(_repositorioGrupos.ListarPorId(new Guid(id))).Construir();
        }

        public IEnumerable<Grupo> Localizar()
        {
            return new ConstrutorListaGrupoDto(_repositorioGrupos.ListarTodos()).Construir();
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