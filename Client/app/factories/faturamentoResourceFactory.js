(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .factory("faturamentoResourceFactory", function($resource, constantesService) {
            return {
                faturas: $resource(constantesService.baseUrl() + "faturas/:id", null,
                    { 'update': { method: "PUT" } }),

                atual: $resource(constantesService.baseUrl() + "faturas/atual")
            }
        });
})();

