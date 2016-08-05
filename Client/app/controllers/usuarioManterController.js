(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("usuarioManterController", function($filter, $sce, $location, $stateParams, growlService, grupoService, usuarioService) {
            var vm = this;

            vm.usuario = {};
            vm.grupos = null;
            vm.tipos = null;
            vm.deveMostrarSenha = deveMostrarSenha;
            vm.devePermitirSelecaoGrupos = devePermitirSelecaoGrupos;
            vm.salvar = salvar;
            vm.cancelar = cancelar;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                var usuarioId = $stateParams.usuarioId;
                vm.tipos = montaTipos();

                if (usuarioId != null && usuarioId.length > 0) {
                    usuarioService.listarPorId(usuarioId).$promise
                        .then(function(resultado) {
                            vm.usuario = resultado;
                        });
                }

                grupoService.listar().$promise
                    .then(function(resultado) {
                        vm.grupos = resultado;
                    });
            }

            function salvar() {

                if (!devePermitirSelecaoGrupos())
                    vm.usuario.grupos = null;

                if (usuarioNovo()) {
                    usuarioService.inserir(vm.usuario)
                        .$promise.then(
                            function() {
                                growlService.growlSuccess("Inclusão efetuada com sucesso.");
                                $location.path("/usuarios");
                            },
                            function(erro) {
                                growlService.growlError(erro.data.Mensagem);
                            });
                } else {
                    usuarioService.atualizar(vm.usuario)
                        .$promise.then(
                            function() {
                                growlService.growlSuccess("Alteração efetuada com sucesso.");
                                $location.path("/usuarios");
                            },
                            function(erro) {
                                growlService.growlError(erro.data.Mensagem);
                            });
                }
            };

            function cancelar() {
                $location.path("/usuarios");
            };

            function montaTipos() {
                return [
                    { 'id': 1, 'nome': "Administrador" },
                    { 'id': 2, 'nome': "Manutenedor" },
                    { 'id': 3, 'nome': "Consumidor" }
                ];
            }

            function deveMostrarSenha() {
                return usuarioNovo();
            }

            function devePermitirSelecaoGrupos() {
                return vm.usuario.tipo === 3;
            }

            function usuarioNovo() {
                return vm.usuario.id == null || vm.usuario.id.length === 0;
            }
        });
})();