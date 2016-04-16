(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("grupoController", function($filter, $sce, ngTableParams, growlService, grupoService) {
            var vm = this;

            vm.parametrosTabela = null;
            vm.grupos = null;
            vm.adicionar = adicionar;
            vm.cancelar = cancelar;
            vm.salvar = salvar;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                grupoService.listar().$promise
                    .then(function(resultado) {
                        vm.grupos = resultado;

                        for (var i = 0; i < vm.grupos.length; i++) {
                            vm.grupos[i].nomeAnterior = vm.grupos[i].nome;
                        }

                        vm.parametrosTabela = new ngTableParams({
                            page: 1,
                            count: 10
                        },
                        {
                            total: resultado.length,
                            getData: function($defer, params) {
                                var gruposTratados = params.filter() ? $filter("filter")(resultado, params.filter()) : resultado;
                                this.id = gruposTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                this.nome = gruposTratados.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                params.total(gruposTratados.length);
                                $defer.resolve(this.id, this.nome);
                            }
                        });
                    });
            }

            function tratarGrupoEditado(grupo, formularioGrupo, estaCancelando) {
                grupo.estaEditando = false;
                formularioGrupo.$setPristine();

                for (var i = 0; i < vm.grupos.length; i++) {
                    if (vm.grupos[i].id === grupo.id) {

                        if (estaCancelando)
                            vm.grupos[i].nome = vm.grupos[i].nomeAnterior;
                        else
                            vm.grupos[i].nomeAnterior = vm.grupos[i].nome;

                        return vm.grupos[i];
                    }
                }

                return null;
            };

            function adicionar() {
                vm.grupos.unshift({
                    id: "",
                    nome: "",
                    novo: true,
                    estaEditando: true
                });

                vm.parametrosTabela.sorting({});
                vm.parametrosTabela.page(1);
                vm.parametrosTabela.reload();
            };

            function cancelar(grupo, formularioGrupo) {
                var grupoOriginal = tratarGrupoEditado(grupo, formularioGrupo, true);
                angular.extend(grupo, grupoOriginal);
            };

            function salvar(grupo, formularioGrupo) {
                if (grupo.novo)
                    salvarInsercao(grupo, formularioGrupo);
                else
                    salvarAtualizacao(grupo, formularioGrupo);
            };

            function salvarInsercao(grupo, formularioGrupo) {
                grupoService.inserir({
                    id: "",
                    nome: grupo.nome
                }).$promise.then(
                    function(resultado) {
                        var grupoOriginal = tratarGrupoEditado(grupo, formularioGrupo, false);
                        angular.extend(grupoOriginal, grupo);
                        growlService.growlSuccess("Inclusão efetuada com sucesso.");
                    },
                    function(erro) {
                        growlService.growlError(erro.data.Mensagem);
                    });
            }

            function salvarAtualizacao(grupo, formularioGrupo) {
                grupoService.atualizar({
                    id: grupo.id,
                    nome: grupo.nome
                }).$promise.then(
                    function() {
                        var grupoOriginal = tratarGrupoEditado(grupo, formularioGrupo, false);
                        angular.extend(grupoOriginal, grupo);
                        growlService.growlSuccess("Alteração efetuada com sucesso.");
                    },
                    function(erro) {
                        growlService.growlError(erro.data.Mensagem);
                    });
            }
        });
})();