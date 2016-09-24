(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("siteService", [
            "$resource", "siteResourceFactory", function($resource, siteResourceFactory) {

                this.listar = function () {
                    return siteResourceFactory.sites.get();
                };
            }
        ]);
})();

