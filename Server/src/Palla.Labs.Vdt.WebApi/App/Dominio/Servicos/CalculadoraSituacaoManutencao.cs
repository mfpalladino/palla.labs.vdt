using System;
using System.Linq;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Dominio.Servicos
{
    public class CalculadoraSituacaoManutencao
    {
        private readonly Equipamento _equipamento;

        public CalculadoraSituacaoManutencao(Equipamento equipamento)
        {
            if (equipamento == null)
                throw new ArgumentNullException("equipamento");

            _equipamento = equipamento;
        }

        public SituacaoManutencao Calcular()
        {
            return Calcular(DateTime.Now);
        }

        public SituacaoManutencao Calcular(DateTime dataReferencia)
        {
            var parametrosManutencao = _equipamento.ParametrosManutencao;
            var manutencoes = _equipamento.Manutencoes; 

            if (!parametrosManutencao.ControladaPelasPartes)
                return SituacaoManutencao.Ok;

            foreach (var parte in parametrosManutencao.Partes)
            {
                var nomeParte = parte.Nome;
                var periodoParaManutencaoEmMeses = parte.PeriodoParaManutencaoEmMeses ?? 0;
                var ultimaManutencao = manutencoes.Where(x => x.Parte.Equals(nomeParte)).OrderByDescending(x => x.Data).FirstOrDefault();

                if (ultimaManutencao == null)
                    continue;

                //"-2" porque vai começar a "alarmar" dois meses antes do período de manutenção
                var dataLimiteSemAvisos = ultimaManutencao.Data.AddMonths(periodoParaManutencaoEmMeses - 2);

                if (dataReferencia.Date >= dataLimiteSemAvisos.AddMonths(1) ||
                    dataReferencia.Date >= dataLimiteSemAvisos.AddMonths(2).PrimeiroDiaDoMes())
                    return SituacaoManutencao.EstadoCritico;

                if (dataReferencia.Date >= dataLimiteSemAvisos.AddDays(1) &&
                    dataReferencia.Date <= dataLimiteSemAvisos.AddMonths(1).UltimoDiaDoMes())
                    return SituacaoManutencao.EstadoDeAtencao;
            }

            return SituacaoManutencao.Ok;
        }

    }
}