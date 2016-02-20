using System;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorGrupo
    {
        public Grupo Construir()
        {
            return new Grupo(Guid.NewGuid(), "grupo");
        }
    }
}