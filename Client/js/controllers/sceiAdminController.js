(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("sceiAdminController", function ($timeout, $state) {
            var vm = this;

            if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
                angular.element("html").addClass("ismobile");
            }

            vm.layoutType = "1"; //layout com o menu encaixado à esquerda
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
        });
})();