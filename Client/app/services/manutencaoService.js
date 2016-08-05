(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("manutencaoService", [
            "$resource", "manutencaoResourceFactory", function ($resource, manutencaoResourceFactory) {
                this.listar = function (id) {
                    return manutencaoResourceFactory.manutencoes.query({ id: id });
                };
                this.inserir = function (id, manutencao) {
                    return manutencaoResourceFactory.manutencoes.save({id: id}, manutencao);
                };
            }
        ]);
})();

