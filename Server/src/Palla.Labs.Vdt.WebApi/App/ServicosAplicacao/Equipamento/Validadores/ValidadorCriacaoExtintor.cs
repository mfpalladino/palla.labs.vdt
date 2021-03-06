﻿using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ValidadorCriacaoExtintor : ValidadorEquipamentoBase
    {
        public ValidadorCriacaoExtintor(RepositorioClientes repositorioClientes, RepositorioEquipamentos repositorioEquipamentos)
            : base(repositorioClientes, repositorioEquipamentos)
        {
        }

        public override void Validar(Guid siteId, EquipamentoDto equipamentoDto)
        {
            base.Validar(siteId, equipamentoDto);

            var equipamentoEspecifico = equipamentoDto as ExtintorDto;

            if (equipamentoEspecifico == null)
                throw new Exception("Não é possível validar o equipamento (problema de conversão).");
        }

        public override bool ValidadorDeCriacao
        {
            get { return true; }
        }
    }
}