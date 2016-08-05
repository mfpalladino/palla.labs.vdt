(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("usuarioController", function($filter, $sce, ngTableParams, growlService, usuarioService) {
            var vm = this;

            vm.parametrosTabela = null;
            vm.usuarios = null;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                usuarioService.listar().$promise
                    .then(function(resultado) {
                        vm.usuarios = resultado;

                        vm.parametrosTabela = new ngTableParams({
                            page: 1,
                            count: 10
                        },
                        {
                            total: resultado.length,
                            getData: function($defer, params) {
                                var usuariosTratados = params.filter() ? $filter("filter")(resultado, params.filter()) : resultado;
                                this.id = usuariosTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                this.nome = usuariosTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                this.tipoNome = usuariosTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                params.total(usuariosTratados.length);
                                $defer.resolve(this.id, this.tipoNome, this.nome);
                            }
                        });
                    });
            }
        });
})();