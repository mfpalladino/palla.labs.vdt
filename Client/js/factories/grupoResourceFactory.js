(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .factory("grupoResourceFactory", function($resource, constantesService) {
            return {
                grupos: $resource(constantesService.baseUrl() + "grupos/:id", null,
                    { 'update': { method: "PUT" } }),

                sumarioSituacao: $resource(constantesService.baseUrl() + "grupos/:id/sumariosituacao")
            }
        });
})();

