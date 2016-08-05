(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("clienteManterController", function($filter, $sce, $location, $stateParams, growlService, grupoService, clienteService) {
            var vm = this;

            vm.cliente = {};
            vm.grupos = null;
            vm.salvar = salvar;
            vm.cancelar = cancelar;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                var clienteId = $stateParams.clienteId;

                if (clienteId != null && clienteId.length > 0) {
                    clienteService.listarPorId(clienteId).$promise
                        .then(function(resultado) {
                            vm.cliente = resultado;
                        });
                }

                grupoService.listar().$promise
                    .then(function(resultado) {
                        vm.grupos = resultado;
                    });
            }

            function salvar() {
                var clienteNovo = vm.cliente.id == null || vm.cliente.id.length === 0;

                if (clienteNovo) {
                    clienteService.inserir(vm.cliente)
                        .$promise.then(
                            function() {
                                growlService.growlSuccess("Inclusão efetuada com sucesso.");
                                $location.path("/clientes");
                            },
                            function(erro) {
                                growlService.growlError(erro.data.Mensagem);
                            });
                } else {
                    clienteService.atualizar(vm.cliente)
                        .$promise.then(
                            function() {
                                growlService.growlSuccess("Alteração efetuada com sucesso.");
                                $location.path("/clientes");
                            },
                            function(erro) {
                                growlService.growlError(erro.data.Mensagem);
                            });
                }
            };

            function cancelar() {
                $location.path("/clientes");
            };

        });
})();