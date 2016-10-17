(function () {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("faturamentoController", function ($filter, $sce, $location, $window, growlService, siteService, loginService, faturamentoService) {
            var vm = this;
            vm.site = null;
            vm.faturaAtual = null;
            vm.estaEfetuandoPagamento = false;
            vm.pagar = pagar;

            montaFaturaAtual();

            //////////

            function montaFaturaAtual() {
                vm.dominio = loginService.recuperarDadosLogin().dominio;

                faturamentoService.listarFaturaAtual().$promise
                    .then(function (resultado) {
                        vm.faturaAtual = resultado;
                    });

                siteService.listar().$promise
                    .then(function (resultado) {
                        vm.site = resultado;
                    });
            };

            function pagar() {
                vm.estaEfetuandoPagamento = true
                faturamentoService.pagar(vm.faturaAtual)
                    .$promise.then(
                    function (resultado) {
                        $window.location.href = resultado.url;
                    },
                    function (erro) {
                        vm.estaEfetuandoPagamento = false
                        growlService.growlError(erro.data.Mensagem);
                    });
            };
        });
})();