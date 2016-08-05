(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .factory("manutencaoResourceFactory", function ($resource, constantesService) {
            return {
                manutencoes: $resource(constantesService.baseUrl() + "equipamentos/:id/manutencoes", null,
                    { 'update': { method: "PUT" } })
            }
        });
})();

