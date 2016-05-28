(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("manutencaoManterController", function ($filter, $sce, $location, $stateParams, growlService, dataHoraService, equipamentoService, manutencaoService) {
            var vm = this;

            vm.equipamento = null;
            vm.partesParaManutencao = null;
            vm.manutencao = {};
            vm.clientes = null;
            vm.salvar = salvar;
            vm.cancelar = cancelar;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                var equipamentoId = $stateParams.equipamentoId;

                if (equipamentoId != null && equipamentoId.length > 0) {
                    equipamentoService.listarPorId(equipamentoId).$promise
                        .then(function(resultado) {
                            vm.equipamento = resultado;
                            vm.partesParaManutencao = resultado.partesParaManutencao;
                            vm.manutencao.parte = vm.partesParaManutencao[0];
                            vm.manutencao.dataComoData = new Date();
                        });
                }
            }

            function salvar() {
                vm.manutencao.data = dataHoraService.dateToUnixDate(vm.manutencao.dataComoData);
                manutencaoService.inserir(vm.equipamento.id, vm.manutencao)
                    .$promise.then(
                        function() {
                            growlService.growlSuccess("Manutenção registrada com sucesso.");
                            $location.path("/manutencoes");
                        },
                        function(erro) {
                            growlService.growlError(erro.data.Mensagem);
                        });
            };

            function cancelar() {
                $location.path("/manutencoes");
            };
        });
})();