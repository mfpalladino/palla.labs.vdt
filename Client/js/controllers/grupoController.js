(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .controller("grupoController", function ($filter, $sce, ngTableParams, grupoService) {
            var vm = this;

            vm.data = null;
            vm.tableFilter = null;

            grupoService.listar().$promise
                .then(function(resultado) {
                    vm.data = resultado;
                    vm.tableFilter = new ngTableParams({
                        page: 1,
                        count: 10
                    }, {
                        total: resultado.length,
                        getData: function($defer, params) {
                            var orderedData = params.filter() ? $filter("filter")(resultado, params.filter()) : resultado;

                            this.id = orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count());
                            this.nome = orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count());

                            params.total(orderedData.length);
                            $defer.resolve(this.id, this.nome);
                        }
                    });
                });
        });
})();