using System;
using AutoMapper;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.AutoMapper;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class CriadorGrupo
    {
        private readonly RepositorioGrupos _repositorioGrupos;
        private readonly IMapper _mapeador;

        public CriadorGrupo(RepositorioGrupos repositorioGrupos, IMapper mapeador)
        {
            _repositorioGrupos = repositorioGrupos;
            _mapeador = mapeador;
        }

        public Grupo Criar(GrupoDto grupoDto)
        {
            Validar(grupoDto);

            var grupo = _mapeador.ParaEntidade<Grupo, GrupoDto>(grupoDto);
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