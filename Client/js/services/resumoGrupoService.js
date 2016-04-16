(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("resumoGrupoService", [
            "$resource", "grupoResourceFactory", function ($resource, grupoResourceFactory) {
                this.pegaTodosGrupos = function(recuperouSumarioSituacao) {
                    return grupoResourceFactory.grupos.query(function (grupos) {
                        grupos.forEach(function(item) {
                            grupoResourceFactory.sumarioSituacao.get({ id: item.id }, function (sumarioSituacao) {
                                item.sumarioSituacao = sumarioSituacao;
                                recuperouSumarioSituacao(item);
                            });
                        });
                    });
                }
            }
        ]);
})();

