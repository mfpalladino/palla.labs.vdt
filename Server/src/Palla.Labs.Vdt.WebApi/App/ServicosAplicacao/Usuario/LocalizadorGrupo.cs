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
    public class LocalizadorUsuario
    {
        private readonly RepositorioUsuarios _repositorioUsuarios;
        private readonly FabricaUsuarioDto _fabricaUsuarioDto;
        private readonly FabricaSumarioSituacaoDto _fabricaSumarioSituacaoDto;

        public LocalizadorUsuario(RepositorioUsuarios repositorioUsuarios, FabricaUsuarioDto fabricaUsuarioDto, FabricaSumarioSituacaoDto fabricaSumarioSituacaoDto)
        {
            _repositorioUsuarios = repositorioUsuarios;
            _fabricaUsuarioDto = fabricaUsuarioDto;
            _fabricaSumarioSituacaoDto = fabricaSumarioSituacaoDto;
        }

        public UsuarioDto Localizar(Guid siteId, string id)
        {
            Validar(siteId, id);
            return _fabricaUsuarioDto.Criar(_repositorioUsuarios.BuscarPorId(siteId, new Guid(id)));
        }

        public IEnumerable<UsuarioDto> Localizar(Guid siteId)
        {
            return _fabricaUsuarioDto.Criar(_repositorioUsuarios.Buscar(siteId));
        }

        public SumarioSituacaoDto SumarioSituacao(IEnumerable<EquipamentoDto> equipamentos)
        {
            return _fabricaSumarioSituacaoDto.Criar(equipamentos);
        }

        private void Validar(Guid siteId, string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de usuario informado não é válido.");

            if (_repositorioUsuarios.BuscarPorId(siteId, new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Usuario não encontrado");
        }
    }
}