(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("grupoService", [
            "$resource", "grupoResourceFactory", function ($resource, grupoResourceFactory) {
                this.listar = function () {
                    return grupoResourceFactory.listaGrupos.query();
                }
            }
        ]);
})();

