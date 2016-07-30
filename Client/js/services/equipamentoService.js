(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("equipamentoService", [
            "$resource", "equipamentoResourceFactory", "manutencaoResourceFactory", function ($resource, equipamentoResourceFactory) {

                this.listarPorId = function (id) {
                    return equipamentoResourceFactory.equipamentos.get({ id: id });
                };

                this.listar = function() {
                    return equipamentoResourceFactory.equipamentos.query();
                };

                this.listarPorSituacaoDoGrupo = function (grupoId, situacaoId) {
                    if (situacaoId === 1)
                        return equipamentoResourceFactory.equipamentosOk.query({ grupoId: grupoId });
                    if (situacaoId === 2)
                        return equipamentoResourceFactory.equipamentosAtencao.query({ grupoId: grupoId });
                    if (situacaoId === 3)
                        return equipamentoResourceFactory.equipamentosCritico.query({ grupoId: grupoId });

                    return equipamentoResourceFactory.equipamentosInconclusivo.query({ grupoId: grupoId });
                };

                this.listarPorCliente = function (clienteId) {
                    return equipamentoResourceFactory.equipamentos.query({ clienteId: clienteId });
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

