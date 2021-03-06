﻿using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class ParametrosManutencaoCentralAlarme : ParametrosManutencao
    {
        public override bool ControladaPelasPartes
        {
            get { return false; }
        }

        public override IEnumerable<ParteEquipamento> Partes
        {
            get
            {
                return new List<ParteEquipamento>
                {
                    new ParteEquipamento(ParteEquipamento.CentralAlarme)
                };
            }
        }
    }
}