(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("clienteController", function($filter, $sce, ngTableParams, growlService, clienteService) {
            var vm = this;

            vm.parametrosTabela = null;
            vm.clientes = null;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                clienteService.listar().$promise
                    .then(function(resultado) {
                        vm.clientes = resultado;

                        vm.parametrosTabela = new ngTableParams({
                            page: 1,
                            count: 10
                        },
                        {
                            total: resultado.length,
                            getData: function($defer, params) {
                                var clientesTratados = params.filter() ? $filter("filter")(resultado, params.filter()) : resultado;
                                this.id = clientesTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                this.nome = clientesTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                this.grupoNome = clientesTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                params.total(clientesTratados.length);
                                $defer.resolve(this.id, this.grupoNome, this.nome);
                            }
                        });
                    });
            }
        });
})();