using System.Collections.Generic;
using System.Linq;

namespace Palla.Labs.Vdt.App.ServicosAplicacao.Fabricas
{
    public class ConstrutorListaGrupoDto
    {
        private readonly IEnumerable<Dominio.Modelos.Grupo> _grupos;

        public ConstrutorListaGrupoDto(IEnumerable<Dominio.Modelos.Grupo> grupos)
        {
            _grupos = grupos;
        }

        public IEnumerable<Dtos.Grupo> Construir()
        {
            return _grupos.Select(x => new ConstrutorGrupoDto(x).Construir());
        }

    }
}