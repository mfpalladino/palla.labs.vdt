(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("manutencaoController", function ($filter, $sce, ngTableParams, growlService, clienteService, equipamentoService, manutencaoService, dataHoraService) {
            var vm = this;
            vm.clientes = null;
            vm.equipamentos = null;
            vm.manutencoes = null;
            vm.clienteSelecionadoId = null;
            vm.equipamentoSelecionadoId = null;
            vm.clienteSelecionadoMudou = clienteSelecionadoMudou;
            vm.equipamentoSelecionadoMudou = equipamentoSelecionadoMudou;
            vm.clienteEstaSelecionado = clienteEstaSelecionado;
            vm.equipamentoEstaSelecionado = equipamentoEstaSelecionado;
            vm.equipamentoSelecionadoContemManutencoes = equipamentoSelecionadoContemManutencoes;
            vm.equipamentoSelecionadoNaoContemManutencoes = equipamentoSelecionadoNaoContemManutencoes;
            vm.parametrosTabela = null;
            vm.configuraParametrosManutencao = configuraParametrosManutencao;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                clienteService.listar().$promise
                    .then(function (resultado) {
                        vm.clientes = resultado;
                        vm.equipamentoSelecionadoId = null;
                        vm.manutencoes = null;
                    });
            }

            function clienteSelecionadoMudou() {
                if (vm.clienteSelecionadoId != null) {
                    equipamentoService.listarPorCliente(vm.clienteSelecionadoId).$promise
                        .then(function(resultado) {
                            vm.equipamentos = resultado;
                        });
                }
            }

            function equipamentoSelecionadoMudou() {
                if (vm.equipamentoSelecionadoId != null) {
                    manutencaoService.listar(vm.equipamentoSelecionadoId).$promise
                        .then(function(resultado) {
                            for (var i = 0; i < resultado.length; i++) {
                                resultado[i].dataComoData = (new Date(dataHoraService.unixDateToDate(resultado[i].data))).toLocaleDateString();
                            }

                            vm.manutencoes = resultado;
                            vm.parametrosTabela = new ngTableParams({
                                page: 1,
                                count: 100
                            },
                            {
                                total: resultado.length,
                                getData: function($defer, params) {
                                    var manutencoesTratadas = params.filter() ? $filter("filter")(resultado, params.filter()) : resultado;
                                    this.id = manutencoesTratadas.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                    this.data = manutencoesTratadas.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                    this.parte = manutencoesTratadas.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                    params.total(manutencoesTratadas.length);
                                    $defer.resolve(this.id, this.data, this.parte);
                                }
                            });
                        });
                }
            }

            function clienteEstaSelecionado() {
                return vm.clienteSelecionadoId != null;
            }

            function equipamentoEstaSelecionado() {
                return vm.equipamentoSelecionadoId != null;
            }

            function equipamentoSelecionadoContemManutencoes() {
                return vm.manutencoes != null && vm.manutencoes.length > 0;
            }

            function equipamentoSelecionadoNaoContemManutencoes() {
                return vm.manutencoes == null || vm.manutencoes.length === 0;
            }

            function configuraParametrosManutencao() {
                return {
                    equipamentoId: vm.equipamentoSelecionadoId
                };
            }
        });
})();