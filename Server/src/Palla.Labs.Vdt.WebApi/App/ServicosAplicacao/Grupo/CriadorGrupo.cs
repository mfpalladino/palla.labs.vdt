using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class CriadorGrupo
    {
        private readonly RepositorioGrupos _repositorioGrupos;
        private readonly FabricaGrupo _fabricaGrupo;
        private readonly FabricaGrupoDto _fabricaGrupoDto;

        public CriadorGrupo(RepositorioGrupos repositorioGrupos, 
            FabricaGrupo fabricaGrupo,
            FabricaGrupoDto fabricaGrupoDto)
        {
            _repositorioGrupos = repositorioGrupos;
            _fabricaGrupo = fabricaGrupo;
            _fabricaGrupoDto = fabricaGrupoDto;
        }

        public GrupoDto Criar(Guid siteId, GrupoDto grupoDto)
        {
            if (grupoDto.Id != Guid.Empty)
                throw new FormatoInvalido("O identificador de grupo não deve ser informado neste contexto.");

            var grupo = _fabricaGrupo.Criar(siteId, Guid.NewGuid(), grupoDto);
            _repositorioGrupos.Inserir(grupo);
            return _fabricaGrupoDto.Criar(grupo);
        }
    }
}