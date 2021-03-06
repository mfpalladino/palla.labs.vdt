﻿using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Compartilhado;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public abstract class ParametrosManutencao
    {
        public virtual bool UtilizaDataBaseParaPrimeiraMenutencao
        {
            get { return false; }
        }

        public virtual long DataBasePrimeiraManutencao
        {
            get { return DateTime.Now.ParaUnixTime(); }
        }

        public virtual bool ControladaPelasPartes
        {
            get { return true; }
        }

        public abstract IEnumerable<ParteEquipamento> Partes { get; }
    }
}