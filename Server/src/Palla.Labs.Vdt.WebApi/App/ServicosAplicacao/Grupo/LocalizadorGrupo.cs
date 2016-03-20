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
        private readonly FabricaSumarioSituacaoDto _fabricaSumarioSituacaoDto;

        public LocalizadorGrupo(RepositorioGrupos repositorioGrupos, FabricaGrupoDto fabricaGrupoDto, FabricaSumarioSituacaoDto fabricaSumarioSituacaoDto)
        {
            _repositorioGrupos = repositorioGrupos;
            _fabricaGrupoDto = fabricaGrupoDto;
            _fabricaSumarioSituacaoDto = fabricaSumarioSituacaoDto;
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

        public SumarioSituacaoDto SumarioSituacao(IEnumerable<EquipamentoDto> equipamentos)
        {
            return _fabricaSumarioSituacaoDto.Criar(equipamentos);
        }

        private void Validar(string id)
        {
            if (!id.GuidValido())
                throw new FormatoInvalido("O identificador de grupo informado n�o � v�lido.");

            if (_repositorioGrupos.BuscarPorId(new Guid(id)) == null)
                throw new RecursoNaoEncontrado("Grupo n�o encontrado");
        }
    }
}