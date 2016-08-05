(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("sceiAdminController", function ($timeout, $state, $location, loginService) {
            var vm = this;
            vm.usuarioLogado = usuarioLogado;
            vm.usuarioPodeAcessarUsuarios = usuarioPodeAcessarUsuarios;
            vm.usuarioPodeAcessarClientes = usuarioPodeAcessarClientes;
            vm.usuarioPodeAcessarGruposClientes = usuarioPodeAcessarGruposClientes;
            vm.usuarioPodeAcessarEquipamentos = usuarioPodeAcessarEquipamentos;
            vm.usuarioPodeAcessarManutencoes = usuarioPodeAcessarManutencoes;
            vm.deslogar = deslogar;

            if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
                angular.element("html").addClass("ismobile");
            }

            vm.layoutType = layoutType;
            vm.$state = $state;
            vm.currentSkin = "orange";
            vm.skinList = [
                "lightblue",
                "bluegray",
                "cyan",
                "teal",
                "green",
                "orange",
                "blue",
                "purple"
            ];

            function layoutType() {
                return estaLogado() ? "1" : "0";
            }

            function estaLogado() {
                var token = loginService.recuperarDadosLogin().token;
                return token != null && token.length > 0;
            }

            function usuarioLogado() {
                var usuario = loginService.recuperarDadosLogin().dominio + "\\" +
                    loginService.recuperarDadosLogin().usuario;
                return (usuario != null && usuario.length > 0) ? usuario : "(não há)";
            }

            function usuarioPodeAcessarUsuarios() {
                var permissoes = loginService.recuperarDadosLogin().permissoes;
                return permissoes != null ? permissoes.podeAcessarUsuarios : false;
            }

            function usuarioPodeAcessarClientes() {
                var permissoes = loginService.recuperarDadosLogin().permissoes;
                return permissoes != null ? permissoes.podeAcessarClientes : false;
            }

            function usuarioPodeAcessarGruposClientes() {
                var permissoes = loginService.recuperarDadosLogin().permissoes;
                return permissoes != null ? permissoes.podeAcessarGruposClientes : false;
            }

            function usuarioPodeAcessarEquipamentos() {
                var permissoes = loginService.recuperarDadosLogin().permissoes;
                return permissoes != null ? permissoes.podeAcessarEquipamentos : false;
            }

            function usuarioPodeAcessarManutencoes() {
                var permissoes = loginService.recuperarDadosLogin().permissoes;
                return permissoes != null ? permissoes.podeAcessarManutencoes : false;
            }

            function deslogar() {
                loginService.deslogar();
                $location.path("/login");
            }
        });
})();