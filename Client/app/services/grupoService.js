(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("grupoService", [
            "$resource", "grupoResourceFactory", function($resource, grupoResourceFactory) {

                this.listarPorId = function (id) {
                    return grupoResourceFactory.grupos.get({ id: id });
                };

                this.listar = function () {
                    return grupoResourceFactory.grupos.query();
                };

                this.atualizar = function(grupo) {
                    return grupoResourceFactory.grupos.update({ id: grupo.id }, grupo);
                };

                this.inserir = function (grupo) {
                    return grupoResourceFactory.grupos.save(grupo);
                };
            }
        ]);
})();

