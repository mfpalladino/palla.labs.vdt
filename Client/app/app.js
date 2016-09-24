(function() {
    "use strict";

    angular
        .module("sceiAdmin", [
                "ngAnimate",
                "ngResource",
                "ui.router",
                "ui.bootstrap",
                "angular-loading-bar",
                "oc.lazyLoad",
                "nouislider",
                "ngTable"
    ]);
	
	//Aplicacao
	require("./config.js");
	require("./templates.js");
	require("./controllers/clienteController.js");
	require("./controllers/clienteManterController.js");
	require("./controllers/detalheGrupoController.js");
	require("./controllers/equipamentoController.js");
	require("./controllers/equipamentoManterController.js");
	require("./controllers/grupoController.js");
	require("./controllers/grupoManterController.js");
	require("./controllers/loginController.js");
	require("./controllers/manutencaoController.js");
	require("./controllers/manutencaoManterController.js");
	require("./controllers/resumoGrupoController.js");
	require("./controllers/sceiAdminController.js");
	require("./controllers/usuarioController.js");
	require("./controllers/usuarioManterController.js");
	require("./controllers/faturamentoController.js");
	
	require("./directives/formDirectives.js");
	require("./directives/resumoGrupoDirective.js");
	require("./directives/templateDirectives.js");
	
	require("./factories/clienteResourceFactory.js");
	require("./factories/equipamentoResourceFactory.js");
	require("./factories/grupoResourceFactory.js");
	require("./factories/loginResourceFactory.js");
	require("./factories/manutencaoResourceFactory.js");
	require("./factories/usuarioResourceFactory.js");
	require("./factories/faturamentoResourceFactory.js");
	
	require("./services/clienteService.js");
	require("./services/constantesService.js");
	require("./services/dataHoraService.js");
	require("./services/equipamentoService.js");
	require("./services/growlService.js");
	require("./services/grupoService.js");
	require("./services/loginService.js");
	require("./services/manutencaoService.js");
	require("./services/resumoGrupoService.js");
	require("./services/scrollService.js");
	require("./services/usuarioService.js");
	require("./services/faturamentoService.js");
	
	//Estilo
	require("./assets/less/app.less");
})();