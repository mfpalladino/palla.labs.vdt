(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .factory("grupoResourceFactory", function($resource, constantesService) {
            return {
                atualizar: $resource(constantesService.baseUrl() + "grupos/:id", null, { 'update': { method: "PUT" } }),
                listar: $resource(constantesService.baseUrl() + "grupos"),
                sumarioSituacao: $resource(constantesService.baseUrl() + "grupos/:id/sumariosituacao")
            }
        });
})();

