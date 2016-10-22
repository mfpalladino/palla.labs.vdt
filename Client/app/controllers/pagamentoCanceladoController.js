(function () {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("pagamentoCanceladoController", function ($filter, $sce, $location, growlService, faturamentoService) {
            var vm = this;

            cancelaPagamento();

            function cancelaPagamento() {
                var token = $location.search().token;
                faturamentoService.cancelar(token).$promise.then(
                    function () {
                        growlService.growlSuccess("Pagamento cancelado com sucesso!");
                        $location.search('token', null);
                        $location.path("/faturamento").replace();
                    });
            };
        });
})();