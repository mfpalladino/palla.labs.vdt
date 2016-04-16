(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("grupoService", [
            "$resource", "grupoResourceFactory", function($resource, grupoResourceFactory) {
                this.listar = function() {
                    return grupoResourceFactory.listar.query();
                };

                this.atualizar = function(grupo) {
                    return grupoResourceFactory.atualizar.update({ id: grupo.id }, grupo);
                };
            }
        ]);
})();

