﻿(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("loginController", function ($location, $stateParams, growlService, loginService) {
            var vm = this;
            vm.login = {};
            vm.logar = logar;

            function logar() {
                loginService.logar(vm.login)
                    .$promise.then(
                        function (resultado) {
                            loginService.salvarDadosLogin(resultado.token, vm.login.dominio, resultado.usuario, resultado.permissoes);
                            var mensagemDeBoasVindas = "Olá, " + resultado.usuario + ".";
                            growlService.growlSuccess(mensagemDeBoasVindas);
                            $location.path("/home");
                        },
                        function(erro) {
                            growlService.growlError(erro.data.Mensagem);
                        });
            };
        });
})();