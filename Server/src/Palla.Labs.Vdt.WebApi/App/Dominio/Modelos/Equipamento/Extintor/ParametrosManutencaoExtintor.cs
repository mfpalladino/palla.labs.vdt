using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class ParametrosManutencaoExtintor : ParametrosManutencao
    {
        private readonly long _dataBasePrimeiraManutencao;

        public ParametrosManutencaoExtintor(long dataBasePrimeiraManutencao)
        {
            _dataBasePrimeiraManutencao = dataBasePrimeiraManutencao;
        }

        public override long DataBasePrimeiraManutencao
        {
            get { return _dataBasePrimeiraManutencao; }
        }

        public override bool UtilizaDataBaseParaPrimeiraMenutencao
        {
            get { return true; }
        }

        public override IEnumerable<ParteEquipamento> Partes
        {
            get
            {
                return new List<ParteEquipamento>
                {
                    new ParteEquipamento(ParteEquipamento.EXTINTOR, 12)
                };
            }
        }
    }
}