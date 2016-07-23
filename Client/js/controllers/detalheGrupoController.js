(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("detalheGrupoController", function (parametros, $scope, $uibModalInstance) {
            $scope.grupo = parametros.grupo;
            $scope.estado = parametros.estado;
            $scope.fecharDetalhes = fecharDetalhes;

            ////////////

            function fecharDetalhes() {
                $uibModalInstance.dismiss("cancel");
            }

        });
})();