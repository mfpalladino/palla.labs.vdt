using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class ParametrosManutencaoExtintor : ParametrosManutencao
    {
        private readonly long _fabricadoEm;

        public ParametrosManutencaoExtintor(long fabricadoEm)
        {
            _fabricadoEm = fabricadoEm;
        }

        public override long FabricadoEm
        {
            get { return _fabricadoEm; }
        }

        public override bool UtilizaFabricadoEmQuandoNaoHouverManutencoes
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