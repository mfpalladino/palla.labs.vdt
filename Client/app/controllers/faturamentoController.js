(function () {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("faturamentoController", function ($filter, $sce, loginService, faturamentoService) {
            var vm = this;
            vm.dominio = null;
            vm.faturaAtual = null;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                vm.dominio = loginService.recuperarDadosLogin().dominio;    

                faturamentoService.pegarFaturaAtual().$promise
                    .then(function (resultado) {
                        vm.faturaAtual = resultado;
                    });
            }
        });
})();