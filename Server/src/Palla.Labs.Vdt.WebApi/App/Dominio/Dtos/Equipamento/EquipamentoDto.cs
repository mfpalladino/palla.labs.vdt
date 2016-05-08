using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Dtos
{
    public class EquipamentoDto : DtoBase<Guid>
    {
        public string ClienteId { get; set; }

        public string ClienteNome { get; set; }

        public int Tipo { get; set; }

        public string Nome { get; set; }

        public int SituacaoManutencao { get; set; }
    }
}