using System;

namespace Palla.Labs.Vdt.App.Dominio.Fabricas
{
    public class ConstrutorGrupo
    {
        private readonly ServicosAplicacao.Dtos.Grupo _grupo;
        private Guid _id;

        public ConstrutorGrupo(ServicosAplicacao.Dtos.Grupo grupo)
        {
            _grupo = grupo;
        }

        public ConstrutorGrupo ComId(Guid id)
        {
            _id = id;
            return this;
        }

        public Modelos.Grupo Construir()
        {
            return _id != Guid.Empty ? new Modelos.Grupo(_id, _grupo.Nome) : new Modelos.Grupo(_grupo.Nome);
        }
    }
}