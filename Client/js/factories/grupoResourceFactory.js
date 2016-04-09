(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .factory("grupoResourceFactory", function($resource, constantesService) {
            return {
                listaGrupos: $resource(constantesService.baseUrl() + "grupos"),
                sumarioSituacao: $resource(constantesService.baseUrl() + "grupos/:id/sumariosituacao")
            }
        });
})();

