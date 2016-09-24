(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("faturamentoService", [
            "$resource", "faturamentoResourceFactory", function ($resource, faturamentoResourceFactory) {
                this.listarFaturaAtual = function() {
                    return faturamentoResourceFactory.atual.get();
                };
            }
        ]);
})();

