using System;
using System.Collections.Generic;
using System.Linq;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Servicos
{
    public class CalculadoraSituacaoManutencao
    {
        public SituacaoManutencao Calcular(Equipamento equipamento)
        {
            return Calcular(equipamento, DateTime.Now.ParaUnixTime());
        }

        public SituacaoManutencao Calcular(Equipamento equipamento, long dataReferencia)
        {
            var parametrosManutencao = equipamento.ParametrosManutencao;
            var manutencoes = equipamento.Manutencoes; 

            if (!parametrosManutencao.ControladaPelasPartes)
                return SituacaoManutencao.Ok;

            if (manutencoes == null || manutencoes.Count == 0)
            {
                if (parametrosManutencao.UtilizaDataBaseParaPrimeiraMenutencao)
                    manutencoes = new List<Manutencao>{ new Manutencao(parametrosManutencao.DataBasePrimeiraManutencao, parametrosManutencao.Partes.First().Nome) };
                else
                    return SituacaoManutencao.Inconclusivo;
            }

            foreach (var parte in parametrosManutencao.Partes)
            {
                var nomeParte = parte.Nome;
                var periodoParaManutencaoEmMeses = parte.PeriodoParaManutencaoEmMeses ?? 0;
                var ultimaManutencao = manutencoes.Where(x => x.Parte.Equals(nomeParte)).OrderByDescending(x => x.Data).FirstOrDefault();

                if (ultimaManutencao == null)
                    continue;

                //"-2" porque vai começar a "alarmar" dois meses antes do período de manutenção
                var dataLimiteSemAvisos = ultimaManutencao.Data.APartirDeUnixTime().AddMonths(periodoParaManutencaoEmMeses - 2);

                if (dataReferencia.APartirDeUnixTime().Date >= dataLimiteSemAvisos.AddMonths(1) ||
                    dataReferencia.APartirDeUnixTime().Date >= dataLimiteSemAvisos.AddMonths(2).PrimeiroDiaDoMes())
                    return SituacaoManutencao.EstadoCritico;

                if (dataReferencia.APartirDeUnixTime().Date >= dataLimiteSemAvisos.AddDays(1) &&
                    dataReferencia.APartirDeUnixTime().Date <= dataLimiteSemAvisos.AddMonths(1).UltimoDiaDoMes())
                    return SituacaoManutencao.EstadoDeAtencao;
            }

            return SituacaoManutencao.Ok;
        }
    }
}