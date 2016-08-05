(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .factory("clienteResourceFactory", function($resource, constantesService) {
            return {
                clientes: $resource(constantesService.baseUrl() + "clientes/:id", null,
                    { 'update': { method: "PUT" } })
            }
        });
})();

