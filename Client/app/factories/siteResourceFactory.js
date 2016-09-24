(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .factory("siteResourceFactory", function($resource, constantesService) {
            return {
                sites: $resource(constantesService.baseUrl() + "sites/:id", null,
                    { 'update': { method: "PUT" } })
            }
        });
})();

