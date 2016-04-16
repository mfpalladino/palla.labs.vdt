(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("constantesService", [
            function() {
                this.baseUrl = function() {
                    return "http://vendeta.azurewebsites.net/server/";
                }
            }
        ]);
})();

