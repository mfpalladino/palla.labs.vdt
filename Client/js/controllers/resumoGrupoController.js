(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("resumoGrupoController", function (resumoGrupoService) {
            var vm = this;

            vm.grupos = grupos();

            ////////////

            function grupos() {
                return resumoGrupoService.pegaTodosGrupos(recuperouSumarioSituacao);
            };

            function recuperouSumarioSituacao(grupo) {
                var classeGraficoOk = ".grupo-" + grupo.id + " .ok-pie";
                var classeGraficoAtencao = ".grupo-" + grupo.id + " .atencao-pie";
                var classeGraficoCritico = ".grupo-" + grupo.id + " .critico-pie";
                var classeGraficoInconclusivo = ".grupo-" + grupo.id + " .inconclusivo-pie";

                $(classeGraficoOk).data("easyPieChart").update(grupo.sumarioSituacao.percentualOk);
                $(classeGraficoAtencao).data("easyPieChart").update(grupo.sumarioSituacao.percentualAtencao);
                $(classeGraficoCritico).data("easyPieChart").update(grupo.sumarioSituacao.percentualCritico);
                $(classeGraficoInconclusivo).data("easyPieChart").update(grupo.sumarioSituacao.percentualInconclusivo);
            };
        });
})();