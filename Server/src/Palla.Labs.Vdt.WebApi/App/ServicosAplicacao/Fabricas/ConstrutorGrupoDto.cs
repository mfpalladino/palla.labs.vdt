namespace Palla.Labs.Vdt.App.ServicosAplicacao.Fabricas
{
    public class ConstrutorGrupoDto
    {
        private readonly Dominio.Modelos.Grupo _grupo;

        public ConstrutorGrupoDto(Dominio.Modelos.Grupo grupo)
        {
            _grupo = grupo;
        }

        public Dtos.Grupo Construir()
        {
            return new Dtos.Grupo
            {
                Id = _grupo.Id,
                Nome = _grupo.Nome
            };
        }
    }
}