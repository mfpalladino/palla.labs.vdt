(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("equipamentoService", [
            "$resource", "equipamentoResourceFactory", function ($resource, equipamentoResourceFactory) {

                this.listarPorId = function (id) {
                    return equipamentoResourceFactory.equipamentos.get({ id: id });
                };

                this.listar = function() {
                    return equipamentoResourceFactory.equipamentos.query();
                };

                this.listarPorCliente = function (clienteId) {
                    return equipamentoResourceFactory.equipamentos.query({ clienteId: clienteId });
                };

                this.listarManutencoes = function (id) {
                    return equipamentoResourceFactory.manutencoes.query({ id: id });
                };

                this.atualizar = function (equipamento) {
                    return equipamentoResourceFactory.equipamentos.update({ id: equipamento.id }, equipamento);
                };

                this.inserir = function (equipamento) {
                    return equipamentoResourceFactory.equipamentos.save(equipamento);
                };
            }
        ]);
})();

