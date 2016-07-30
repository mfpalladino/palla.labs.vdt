(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("detalheGrupoController", function (parametros, equipamentoService, loginService, $scope, $uibModalInstance) {
            $scope.grupo = parametros.grupo;
            $scope.situacaoNome = parametros.situacaoNome;
            $scope.situacaoId = parametros.situacaoId;
            $scope.fecharDetalhes = fecharDetalhes;
            $scope.haDetalhes = haDetalhes;
            $scope.usuarioPodeAcessarEquipamentos = usuarioPodeAcessarEquipamentos;
            $scope.usuarioPodeAcessarManutencoes = usuarioPodeAcessarManutencoes;
            $scope.parametrosTabela = null;
            $scope.equipamentos = null;


            montaEquipamentos();

            ////////////

            function montaEquipamentos() {
                equipamentoService.listarPorSituacaoDoGrupo($scope.grupo.id, $scope.situacaoId).$promise
                    .then(function (resultado) {
                        $scope.equipamentos = resultado;
                    });
            }

            function fecharDetalhes() {
                $uibModalInstance.dismiss("cancel");
            }

            function haDetalhes() {
                return $scope.equipamentos != null && $scope.equipamentos.length > 0;
            }

            function usuarioPodeAcessarEquipamentos() {
                var permissoes = loginService.recuperarDadosLogin().permissoes;
                return permissoes != null ? permissoes.podeAcessarEquipamentos : false;
            }

            function usuarioPodeAcessarManutencoes() {
                var permissoes = loginService.recuperarDadosLogin().permissoes;
                return permissoes != null ? permissoes.podeAcessarManutencoes : false;
            }

        });
})();