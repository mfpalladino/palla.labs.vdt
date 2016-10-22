(function () {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("pagamentoConfirmadoController", function ($filter, $sce, $location, growlService, faturamentoService) {
            var vm = this;

            confirmaPagamento();

            function confirmaPagamento() {
                var token = $location.search().token;
                var paymentId = $location.search().paymentId;
                var payerID = $location.search().PayerID;

                faturamentoService.confirmar(token, paymentId, payerID)
                    .$promise.then(
                    function () {
                        $location.search('token', null);
                        $location.search('paymentId', null);
                        $location.search('PayerID', null);
                        growlService.growlSuccess("Pagamento efetivado com sucesso!");
                        $location.path("/home").replace();
                    },
                    function (erro) {
                        $location.search('token', null);
                        $location.search('paymentId', null);
                        $location.search('PayerID', null);
                        growlService.growlError("Infelizmente não conseguimos efetivar o pagamento.");
                        $location.path("/faturamento").replace();
                    });
            };
        });
})();