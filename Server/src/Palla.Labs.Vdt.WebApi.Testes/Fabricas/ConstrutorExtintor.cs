using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorExtintor
    {
        public Extintor Construir()
        {
            return new Extintor("111", "agente", "localização", DateTime.Now, new List<Manutencao>()); 
        }
    }
}
