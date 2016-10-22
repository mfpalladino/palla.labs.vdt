(function () {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("faturamentoService", [
            "$resource", "faturamentoResourceFactory", function ($resource, faturamentoResourceFactory) {
                this.listarFaturaAtual = function () {
                    return faturamentoResourceFactory.atual.get();
                };

                this.pagar = function (fatura) {
                    return faturamentoResourceFactory.faturas.save(fatura);
                };

                this.cancelar = function (tokenCancelamento) {
                    return faturamentoResourceFactory.pagamentoCancelado.save({token:tokenCancelamento});
                };

                this.confirmar = function (tokenConfirmacao, paymentId, payerID) {
                    return faturamentoResourceFactory.pagamentoConfirmado.save(
                        {
                            token:tokenConfirmacao,
                            pagamentoId:paymentId,
                            pagadorId:payerID
                        });
                };
            }
        ]);
})();

