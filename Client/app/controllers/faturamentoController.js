(function () {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("faturamentoController", function ($filter, $sce, siteService, loginService, faturamentoService) {
            var vm = this;
            vm.site = null;
            vm.faturaAtual = null;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                vm.dominio = loginService.recuperarDadosLogin().dominio;    

                faturamentoService.listarFaturaAtual().$promise
                    .then(function (resultado) {
                        vm.faturaAtual = resultado;
                    });

                siteService.listar().$promise
                    .then(function (resultado) {
                        vm.site = resultado;
                    });
            }
        });
})();