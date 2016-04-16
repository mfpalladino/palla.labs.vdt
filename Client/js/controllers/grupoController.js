(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("grupoController", function($filter, $sce, ngTableParams, growlService, grupoService) {
        var vm = this;

        vm.grupos = null;
        vm.tabela = null;

        vm.cancelar = cancelar;
        vm.salvar = salvar;

        grupoService.listar().$promise
            .then(function(resultadoConsulta) {
                vm.grupos = resultadoConsulta;

                for (var i = 0; i < vm.grupos.length; i++) {
                    vm.grupos[i].nomeAnterior = vm.grupos[i].nome;
                }

                vm.tabela = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    total: resultadoConsulta.length,
                    getData: function($defer, params) {
                        var orderedData = params.filter() ? $filter("filter")(resultadoConsulta, params.filter()) : resultadoConsulta;
                        this.id = orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count());
                        this.nome = orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count());
                        params.total(orderedData.length);
                        $defer.resolve(this.id, this.nome);
                    }
                });
            });

        //////////

        function manipularLinhaEditada(linha, linhaForm, cancelando) {
            linha.isEditing = false;
            linhaForm.$setPristine();

            for (var i = 0; i < vm.grupos.length; i++) {
                if (vm.grupos[i].id === linha.id) {

                    if (cancelando)
                        vm.grupos[i].nome = vm.grupos[i].nomeAnterior;
                    else
                        vm.grupos[i].nomeAnterior = vm.grupos[i].nome;

                    return vm.grupos[i];
                }
            }

            return null;
        };

        function cancelar(linha, linhaForm) {
            var linhaOriginal = manipularLinhaEditada(linha, linhaForm, true);
            angular.extend(linha, linhaOriginal);
        };

        function salvar(linha, linhaForm) {
            grupoService.atualizar({
                id: linha.id,
                nome: linha.nome
            }).$promise.then(
                function() {
                    var linhaOriginal = manipularLinhaEditada(linha, linhaForm, false);
                    angular.extend(linhaOriginal, linha);
                    growlService.growlSuccess("Alteração efetuada com sucesso");
                },
                function(erro) {
                    growlService.growlError(erro.data.Mensagem);
                });
        };
    });
})();