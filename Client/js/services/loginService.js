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
                    localStorage.removeItem("dominio");
                    localStorage.removeItem("permissoes");
                };

                this.salvarDadosLogin = function (token, dominio, usuario, permissoes) {
                    localStorage.token = token;
                    localStorage.usuario = usuario;
                    localStorage.dominio = dominio;
                    localStorage.permissoes = JSON.stringify(permissoes);
                }

                this.recuperarDadosLogin = function() {
                    return {
                        token: localStorage.token,
                        usuario: localStorage.usuario,
                        dominio: localStorage.dominio,
                        permissoes: (localStorage.permissoes != null && localStorage.permissoes.length > 0) ?
                            JSON.parse(localStorage.permissoes) : null
                    };
                }
            }
        ]);
})();

