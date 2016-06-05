(function () {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("loginService", [
            "$resource", "loginResourceFactory", function ($resource, loginResourceFactory) {
                this.logar = function (login) {
                    return loginResourceFactory.login.save(login);
                };

                this.deslogar = function () {
                    localStorage.removeItem("token");
                    localStorage.removeItem("usuario");
                };

                this.salvarTokenComUsuarioLocalmente = function (token, usuario) {
                    localStorage.token = token;
                    localStorage.usuario = usuario;
                }

                this.recuperarTokenComUsuarioLocalmente = function () {
                    return {
                        token: localStorage.token,
                        usuario: localStorage.usuario
                    };
                }
            }
        ]);
})();

