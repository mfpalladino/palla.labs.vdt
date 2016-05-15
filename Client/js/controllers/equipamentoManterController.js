(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("equipamentoManterController", function ($filter, $sce, $location, $stateParams, growlService, dataHoraService,
            clienteService, equipamentoService) {
            var vm = this;

            vm.equipamento = {};
            vm.clientes = null;
            vm.tipos = null;
            vm.tiposMangueiras = null;
            vm.diametrosMangueiras = null;
            vm.comprimentosMangueiras = null;
            vm.tiposCentralAlarmes = null;
            vm.tipoExtintorEstaSelecionado = tipoExtintorEstaSelecionado;
            vm.tipoMangueiraEstaSelecionado = tipoMangueiraEstaSelecionado;
            vm.tipoCentralAlarmeEstaSelecionado = tipoCentralAlarmeEstaSelecionado;
            vm.tipoSistemaContraIncendioEmCoifaEstaSelecionado = tipoSistemaContraIncendioEmCoifaEstaSelecionado;
            vm.algumTipoSelecionado = algumTipoSelecionado;
            vm.salvar = salvar;
            vm.cancelar = cancelar;

            montaDadosIniciais();

            //////////

            function montaDadosIniciais() {
                var equipamentoId = $stateParams.equipamentoId;
                vm.tipos = montaTipos();
                vm.tiposMangueiras = montaTiposMangueira();
                vm.diametrosMangueiras = montaDiametrosMangueira();
                vm.comprimentosMangueiras = montaComprimentosMangueira();
                vm.tiposCentralAlarmes = montaTiposCentralAlarme();

                if (equipamentoId != null && equipamentoId.length > 0) {
                    equipamentoService.listarPorId(equipamentoId).$promise
                        .then(function(resultado) {
                            vm.equipamento = resultado;

                        if (vm.equipamento.tipo === 1)
                            vm.equipamento.fabricadoEmComoData = dataHoraService.unixDateToDate(vm.equipamento.fabricadoEm);
                    });
                }

                clienteService.listar().$promise
                    .then(function(resultado) {
                        vm.clientes = resultado;
                    });
            }

            function montaTipos() {
                return [
                    { 'id': 1, 'nome': "Extintor" },
                    { 'id': 2, 'nome': "Mangueira" },
                    { 'id': 3, 'nome': "Central de alarme" },
                    { 'id': 4, 'nome': "Sistema contra incêndio em coifa" }
                ];
            }

            function montaTiposCentralAlarme() {
                return [
                    { 'id': 1, 'nome': "Analógico" },
                    { 'id': 2, 'nome': "Digital" }
                ];
            }

            function montaComprimentosMangueira() {
                return [
                    { 'id': 1, 'nome': "Quinze metros" },
                    { 'id': 2, 'nome': "Vinte metros" },
                    { 'id': 3, 'nome': "Trinta metros" }
                ];
            }

            function montaDiametrosMangueira() {
                return [
                    { 'id': 1, 'nome': "Um metro e meio" },
                    { 'id': 2, 'nome': "Dois metros e meio" }
                ];
            }

            function montaTiposMangueira() {
                return [
                    { 'id': 1, 'nome': "Tipo 1" },
                    { 'id': 2, 'nome': "Tipo 2" }
                ];
            }

            function tipoExtintorEstaSelecionado() {
                return vm.equipamento.tipo === 1;
            }

            function tipoMangueiraEstaSelecionado() {
                return vm.equipamento.tipo === 2;
            }

            function tipoCentralAlarmeEstaSelecionado() {
                return vm.equipamento.tipo === 3;
            }

            function tipoSistemaContraIncendioEmCoifaEstaSelecionado() {
                return vm.equipamento.tipo === 4;
            }

            function algumTipoSelecionado() {
                return vm.equipamento.tipo != undefined;
            }

            function salvar() {
                var equipamentoNovo = vm.equipamento.id == null || vm.equipamento.id.length === 0;

                if (vm.equipamento.tipo === 1)
                    vm.equipamento.fabricadoEm = dataHoraService.dateToUnixDate(vm.equipamento.fabricadoEmComoData);

                if (equipamentoNovo) {
                    equipamentoService.inserir(vm.equipamento)
                        .$promise.then(
                            function() {
                                growlService.growlSuccess("Inclusão efetuada com sucesso.");
                                $location.path("/equipamentos");
                            },
                            function(erro) {
                                growlService.growlError(erro.data.Mensagem);
                            });
                } else {
                    equipamentoService.atualizar(vm.equipamento)
                        .$promise.then(
                            function() {
                                growlService.growlSuccess("Alteração efetuada com sucesso.");
                                $location.path("/equipamentos");
                            },
                            function(erro) {
                                growlService.growlError(erro.data.Mensagem);
                            });
                }
            };

            function cancelar() {
                $location.path("/equipamentos");
            };

        });
})();