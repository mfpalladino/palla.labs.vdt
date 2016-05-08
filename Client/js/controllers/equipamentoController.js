(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("equipamentoController", function($filter, $sce, ngTableParams, growlService, equipamentoService) {
            var vm = this;

            vm.parametrosTabela = null;
            vm.equipamentos = null;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                equipamentoService.listar().$promise
                    .then(function(resultado) {
                        vm.equipamentos = resultado;

                        vm.parametrosTabela = new ngTableParams({
                            page: 1,
                            count: 10
                        },
                        {
                            total: resultado.length,
                            getData: function($defer, params) {
                                var equipamentosTratados = params.filter() ? $filter("filter")(resultado, params.filter()) : resultado;
                                this.id = equipamentosTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                this.nome = equipamentosTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                this.clienteNome = equipamentosTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                params.total(equipamentosTratados.length);
                                $defer.resolve(this.id, this.clienteNome, this.nome);
                            }
                        });
                    });
            }
        });
})();