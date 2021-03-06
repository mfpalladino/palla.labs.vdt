﻿using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorExtintor
    {
        private readonly List<Manutencao> _manutencoes = new List<Manutencao>();
        private Guid _siteId;
        private DateTime _dataFabricacao = DateTime.Now;

        public ConstrutorExtintor NoSite(Guid siteId)
        {
            _siteId = siteId;
            return this;
        }

        public ConstrutorExtintor ComDataDeFabricacao(DateTime dataFabricacao)
        {
            _dataFabricacao = dataFabricacao;
            return this;
        }

        public ConstrutorExtintor ComManutencao(DateTime data)
        {
            _manutencoes.Add(new Manutencao(data.ParaUnixTime(), ParteEquipamento.Extintor));
            return this;
        }

        public Extintor Construir()
        {
            return new Extintor(_siteId, Guid.NewGuid(), "111", "agente", "localização", _dataFabricacao.ParaUnixTime(), _manutencoes, true); 
        }
    }
}
