(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("usuarioService", [
            "$resource", "usuarioResourceFactory", function($resource, usuarioResourceFactory) {

                this.listarPorId = function (id) {
                    return usuarioResourceFactory.usuarios.get({ id: id });
                };

                this.listar = function () {
                    return usuarioResourceFactory.usuarios.query();
                };

                this.atualizar = function(usuario) {
                    return usuarioResourceFactory.usuarios.update({ id: usuario.id }, usuario);
                };

                this.inserir = function (usuario) {
                    return usuarioResourceFactory.usuarios.save(usuario);
                };
            }
        ]);
})();

