(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .factory("loginResourceFactory", function($resource, constantesService) {
            return {
                login: $resource(constantesService.baseUrl() + "login/:id", null)
            }
        });
})();

