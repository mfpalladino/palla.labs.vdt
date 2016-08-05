(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("grupoController", function($filter, $sce, ngTableParams, growlService, grupoService) {
            var vm = this;

            vm.parametrosTabela = null;
            vm.grupos = null;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                grupoService.listar().$promise
                    .then(function(resultado) {
                        vm.grupos = resultado;

                        vm.parametrosTabela = new ngTableParams({
                            page: 1,
                            count: 10
                        },
                        {
                            total: resultado.length,
                            getData: function($defer, params) {
                                var gruposTratados = params.filter() ? $filter("filter")(resultado, params.filter()) : resultado;
                                this.id = gruposTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                this.nome = gruposTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                this.grupoNome = gruposTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                params.total(gruposTratados.length);
                                $defer.resolve(this.id, this.grupoNome, this.nome);
                            }
                        });
                    });
            }
        });
})();