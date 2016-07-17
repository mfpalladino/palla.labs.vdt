(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("resumoGrupoController", function (resumoGrupoService) {
            var vm = this;
            vm.classeDoGrupo = classeDoGrupo;
            vm.grupos = grupos();
            vm.deveMostrarGrupo = deveMostrarGrupo;
            vm.mostrarOK = true;
            vm.mostrarAtencao = true;
            vm.mostrarCritico = true;

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

            function classeDoGrupo(grupo) {
                if (grupo.sumarioSituacao != null) {
                    if (grupo.sumarioSituacao.percentualOk >= 76)
                        return "bgm-lightgreen";
                    if (grupo.sumarioSituacao.percentualOk < 75 && grupo.sumarioSituacao.percentualOk >= 51)
                        return "bgm-amber";
                }

                return "bgm-red";
            }

            function deveMostrarGrupo(grupo) {
                if (grupo.sumarioSituacao != null) {
                    if (grupo.sumarioSituacao.percentualOk >= 76 && vm.mostrarOK)
                        return true;
                    if (grupo.sumarioSituacao.percentualOk < 75 && grupo.sumarioSituacao.percentualOk >= 51 && vm.mostrarAtencao)
                        return true;
                    if (grupo.sumarioSituacao.percentualOk < 51 && vm.mostrarCritico)
                        return true;
                }

                return false;
            }

        });
})();