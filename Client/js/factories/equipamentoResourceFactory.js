(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .factory("equipamentoResourceFactory", function($resource, constantesService) {
            return {
                equipamentos: $resource(constantesService.baseUrl() + "equipamentos/:id", null,
                    { 'update': { method: "PUT" } }),
                manutencoes: $resource(constantesService.baseUrl() + "equipamentos/:id/manutencoes", null,
                    { 'update': { method: "PUT" } })
            }
        });
})();

