(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .factory("equipamentoResourceFactory", function($resource, constantesService) {
            return {
                equipamentos: $resource(constantesService.baseUrl() + "equipamentos/:id", null,
                    { 'update': { method: "PUT" } }),
                equipamentosOk: $resource(constantesService.baseUrl() + "equipamentos?referenciaSituacao=-1&grupoId=:grupoId&situacaoId=1"),
                equipamentosAtencao: $resource(constantesService.baseUrl() + "equipamentos?referenciaSituacao=-1&grupoId=:grupoId&situacaoId=2"),
                equipamentosCritico: $resource(constantesService.baseUrl() + "equipamentos?referenciaSituacao=-1&grupoId=:grupoId&situacaoId=3"),
                equipamentosInconclusivo: $resource(constantesService.baseUrl() + "equipamentos?referenciaSituacao=-1&grupoId=:grupoId&situacaoId=4")
            }
        });
})();

