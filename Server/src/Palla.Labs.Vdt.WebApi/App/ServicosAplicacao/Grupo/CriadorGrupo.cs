using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class CriadorGrupo
    {
        private readonly RepositorioGrupos _repositorioGrupos;
        private readonly FabricaGrupo _fabricaGrupo;

        public CriadorGrupo(RepositorioGrupos repositorioGrupos, FabricaGrupo fabricaGrupo)
        {
            _repositorioGrupos = repositorioGrupos;
            _fabricaGrupo = fabricaGrupo;
        }

        public Grupo Criar(GrupoDto grupoDto)
        {
            Validar(grupoDto);

            var grupo = _fabricaGrupo.Criar(Guid.NewGuid(), grupoDto);
            _repositorioGrupos.Inserir(grupo);
            return grupo;
        }

        private static void Validar(GrupoDto grupoDto)
        {
            if (grupoDto.Id != Guid.Empty)
                throw new FormatoInvalido("O identificador de grupo não deve ser informado neste contexto.");
        }
    }
}