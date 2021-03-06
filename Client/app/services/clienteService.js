(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("clienteService", [
            "$resource", "clienteResourceFactory", function ($resource, clienteResourceFactory) {

                this.listarPorId = function (id) {
                    return clienteResourceFactory.clientes.get({ id: id });
                };

                this.listar = function() {
                    return clienteResourceFactory.clientes.query();
                };

                this.atualizar = function(cliente) {
                    return clienteResourceFactory.clientes.update({ id: cliente.id }, cliente);
                };

                this.inserir = function (cliente) {
                    return clienteResourceFactory.clientes.save(cliente);
                };
            }
        ]);
})();

