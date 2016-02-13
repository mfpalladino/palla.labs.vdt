// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public struct ParteEquipamento
    {
        public const string CO2 = "CO2";
        public const string MANGUEIRA = "Mangueira";
        public const string EXTINTOR = "Extintor";
        public const string SAPONIFICANTE = "Saponificante";
        public const string CENTRAL_ALARME = "CentralAlarme";


        private readonly string _nome;
        private readonly int? _periodoParaManutencaoEmMeses;

        public ParteEquipamento(string nome, int periodoParaManutencaoEmMeses)
        {
            _nome = nome;
            _periodoParaManutencaoEmMeses = periodoParaManutencaoEmMeses;
        }

        public ParteEquipamento(string nome)
        {
            _nome = nome;
            _periodoParaManutencaoEmMeses = null; //A manutenção não é controlada pelas partes do equipamento
        }

        public string Nome
        {
            get { return _nome; }
        }

        public int? PeriodoParaManutencaoEmMeses
        {
            get { return _periodoParaManutencaoEmMeses; }
        }
    }
}