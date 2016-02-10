// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public struct ParteEquipamento
    {
        private readonly string _nome;
        private readonly int _periodoParaManutencaoEmMeses;

        public ParteEquipamento(string nome, int periodoParaManutencaoEmMeses)
        {
            _nome = nome;
            _periodoParaManutencaoEmMeses = periodoParaManutencaoEmMeses;
        }

        public string Nome
        {
            get { return _nome; }
        }

        public int PeriodoParaManutencaoEmMeses
        {
            get { return _periodoParaManutencaoEmMeses; }
        }
    }
}