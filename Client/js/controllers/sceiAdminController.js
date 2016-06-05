(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("sceiAdminController", function ($timeout, $state, $location, loginService) {
            var vm = this;
            vm.usuarioLogado = usuarioLogado;
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
                var token = loginService.recuperarTokenComUsuarioLocalmente().token;
                return token != null && token.length > 0;
            }

            function usuarioLogado() {
                var usuario = loginService.recuperarTokenComUsuarioLocalmente().usuario;
                return (usuario != null && usuario.length > 0) ? usuario : "(não há)";
            }

            function deslogar() {
                loginService.deslogar();
                $location.path("/login");
            }
        });
})();