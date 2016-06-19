(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .factory("usuarioResourceFactory", function($resource, constantesService) {
            return {
                usuarios: $resource(constantesService.baseUrl() + "usuarios/:id", null,
                    { 'update': { method: "PUT" } }),
            }
        });
})();

