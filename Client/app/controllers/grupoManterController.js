(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("grupoManterController", function($filter, $sce, $location, $stateParams, growlService, grupoService) {
            var vm = this;

            vm.grupo = {};
            vm.grupos = null;
            vm.salvar = salvar;
            vm.cancelar = cancelar;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                var grupoId = $stateParams.grupoId;

                if (grupoId != null && grupoId.length > 0) {
                    grupoService.listarPorId(grupoId).$promise
                        .then(function(resultado) {
                            vm.grupo = resultado;
                        });
                }

                grupoService.listar().$promise
                    .then(function(resultado) {
                        vm.grupos = resultado;
                    });
            }

            function salvar() {
                var grupoNovo = vm.grupo.id == null || vm.grupo.id.length === 0;

                if (grupoNovo) {
                    grupoService.inserir(vm.grupo)
                        .$promise.then(
                            function() {
                                growlService.growlSuccess("Inclusão efetuada com sucesso.");
                                $location.path("/grupos");
                            },
                            function(erro) {
                                growlService.growlError(erro.data.Mensagem);
                            });
                } else {
                    grupoService.atualizar(vm.grupo)
                        .$promise.then(
                            function() {
                                growlService.growlSuccess("Alteração efetuada com sucesso.");
                                $location.path("/grupos");
                            },
                            function(erro) {
                                growlService.growlError(erro.data.Mensagem);
                            });
                }
            };

            function cancelar() {
                $location.path("/grupos");
            };

        });
})();