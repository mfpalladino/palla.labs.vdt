(function () {
    "use strict";

    angular
        .module("sceiAdmin")
        .config(function ($httpProvider, $stateProvider, $urlRouterProvider) {

            $urlRouterProvider.otherwise("/login");

            $httpProvider.interceptors.push(function ($location, $q) {
                return {
                    'responseError': function (rejection) {
                        if (rejection.status === 401) {
                            localStorage.token = ""; //todo acessar loginService?
                            $location.path("/login");
                        }

                        return $q.reject(rejection);
                    }
                }
            });

            $httpProvider.interceptors.push(function () {
                return {
                    'request': function (config) {
                        config.headers["Authorization"] = "SCEI-Token " + localStorage.token; //todo acessar loginService?
                        return config;
                    }
                }
            });

            $stateProvider
                .state("login", {
                    url: "/login",
                    templateUrl: "login.html"
                })
                .state("home", {
                    url: "/home",
                    templateUrl: "views/home.html",
                    resolve: {
                        loadPlugin: function ($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "bower_components/fullcalendar/dist/fullcalendar.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    insertBefore: "#app-level-js",
                                    files: [
                                        "custom_components/sparklines/jquery.sparkline.min.js",
                                        "bower_components/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js"
                                    ]
                                }
                            ]);
                        }
                    }
                })
                .state("headers", {
                    url: "/headers",
                    templateUrl: "views/common-2.html"
                })
                .state("headers.textual-menu", {
                    url: "/textual-menu",
                    templateUrl: "views/textual-menu.html"
                })
                .state("headers.image-logo", {
                    url: "/image-logo",
                    templateUrl: "views/image-logo.html"
                })
                .state("headers.mainmenu-on-top", {
                    url: "/mainmenu-on-top",
                    templateUrl: "views/mainmenu-on-top.html"
                })
                .state("grupos", {
                    url: "/grupos",
                    templateUrl: "views/grupos.html"
                })
                .state("adicionarGrupos", {
                    url: "/grupos/novo",
                    templateUrl: "views/grupos-manter.html"
                })
                .state("editarGrupos", {
                    url: "/grupos/:grupoId",
                    templateUrl: "views/grupos-manter.html"
                })
                .state("clientes", {
                    url: "/clientes",
                    templateUrl: "views/clientes.html"
                })
                .state("adicionarClientes", {
                    url: "/clientes/novo",
                    templateUrl: "views/clientes-manter.html",
                    resolve: {
                        loadPlugin: function ($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "bower_components/nouislider/jquery.nouislider.css",
                                        "custom_components/farbtastic/farbtastic.css",
                                        "custom_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "custom_components/input-mask/input-mask.min.js",
                                        "bower_components/nouislider/jquery.nouislider.min.js",
                                        "bower_components/moment/min/moment.min.js",
                                        "custom_components/fileinput/fileinput.min.js",
                                        "custom_components/chosen/chosen.jquery.js",
                                        "bower_components/angular-chosen-localytics/chosen.js",
                                        "bower_components/angular-farbtastic/angular-farbtastic.js"
                                    ]
                                }
                            ]);
                        }
                    }
                })
                .state("editarClientes", {
                    url: "/clientes/:clienteId",
                    templateUrl: "views/clientes-manter.html",
                    resolve: {
                        loadPlugin: function ($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "bower_components/nouislider/jquery.nouislider.css",
                                        "custom_components/farbtastic/farbtastic.css",
                                        "custom_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "custom_components/input-mask/input-mask.min.js",
                                        "bower_components/nouislider/jquery.nouislider.min.js",
                                        "bower_components/moment/min/moment.min.js",
                                        "custom_components/fileinput/fileinput.min.js",
                                        "custom_components/chosen/chosen.jquery.js",
                                        "bower_components/angular-chosen-localytics/chosen.js",
                                        "bower_components/angular-farbtastic/angular-farbtastic.js"
                                    ]
                                }
                            ]);
                        }
                    }
                })
                .state("equipamentos", {
                    url: "/equipamentos",
                    templateUrl: "views/equipamentos.html"
                })
                .state("adicionarEquipamentos", {
                    url: "/equipamentos/novo",
                    templateUrl: "views/equipamentos-manter.html",
                    resolve: {
                        loadPlugin: function ($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "bower_components/nouislider/jquery.nouislider.css",
                                        "custom_components/farbtastic/farbtastic.css",
                                        "custom_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "custom_components/input-mask/input-mask.min.js",
                                        "bower_components/nouislider/jquery.nouislider.min.js",
                                        "bower_components/moment/min/moment.min.js",
                                        "custom_components/fileinput/fileinput.min.js",
                                        "custom_components/chosen/chosen.jquery.js",
                                        "bower_components/angular-chosen-localytics/chosen.js",
                                        "bower_components/angular-farbtastic/angular-farbtastic.js"
                                    ]
                                }
                            ]);
                        }
                    }
                })
                .state("editarEquipamentos", {
                    url: "/equipamentos/:equipamentoId",
                    templateUrl: "views/equipamentos-manter.html",
                    resolve: {
                        loadPlugin: function ($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "bower_components/nouislider/jquery.nouislider.css",
                                        "custom_components/farbtastic/farbtastic.css",
                                        "custom_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "custom_components/input-mask/input-mask.min.js",
                                        "bower_components/nouislider/jquery.nouislider.min.js",
                                        "bower_components/moment/min/moment.min.js",
                                        "custom_components/fileinput/fileinput.min.js",
                                        "custom_components/chosen/chosen.jquery.js",
                                        "bower_components/angular-chosen-localytics/chosen.js",
                                        "bower_components/angular-farbtastic/angular-farbtastic.js"
                                    ]
                                }
                            ]);
                        }
                    }
                })
                .state("criarManutencao", {
                    url: "/equipamentos/:equipamentoId/manutencao",
                    templateUrl: "views/equipamentos-manter-manutencao.html",
                    resolve: {
                        loadPlugin: function ($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "bower_components/nouislider/jquery.nouislider.css",
                                        "custom_components/farbtastic/farbtastic.css",
                                        "custom_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "custom_components/input-mask/input-mask.min.js",
                                        "bower_components/nouislider/jquery.nouislider.min.js",
                                        "bower_components/moment/min/moment.min.js",
                                        "custom_components/fileinput/fileinput.min.js",
                                        "custom_components/chosen/chosen.jquery.js",
                                        "bower_components/angular-chosen-localytics/chosen.js",
                                        "bower_components/angular-farbtastic/angular-farbtastic.js"
                                    ]
                                }
                            ]);
                        }
                    }
                })
                .state("manutencoes", {
                    url: "/manutencoes",
                    templateUrl: "views/manutencoes.html",
                    resolve: {
                        loadPlugin: function ($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "bower_components/nouislider/jquery.nouislider.css",
                                        "custom_components/farbtastic/farbtastic.css",
                                        "custom_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "custom_components/input-mask/input-mask.min.js",
                                        "bower_components/nouislider/jquery.nouislider.min.js",
                                        "bower_components/moment/min/moment.min.js",
                                        "custom_components/fileinput/fileinput.min.js",
                                        "custom_components/chosen/chosen.jquery.js",
                                        "bower_components/angular-chosen-localytics/chosen.js",
                                        "bower_components/angular-farbtastic/angular-farbtastic.js"
                                    ]
                                }
                            ]);
                        }
                    }
                })
                .state("usuarios", {
                    url: "/usuarios",
                    templateUrl: "views/usuarios.html"
                })
                .state("adicionarUsuarios", {
                    url: "/usuarios/novo",
                    templateUrl: "views/usuarios-manter.html",
                    resolve: {
                        loadPlugin: function ($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "bower_components/nouislider/jquery.nouislider.css",
                                        "custom_components/farbtastic/farbtastic.css",
                                        "custom_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "custom_components/input-mask/input-mask.min.js",
                                        "bower_components/nouislider/jquery.nouislider.min.js",
                                        "bower_components/moment/min/moment.min.js",
                                        "custom_components/fileinput/fileinput.min.js",
                                        "custom_components/chosen/chosen.jquery.js",
                                        "bower_components/angular-chosen-localytics/chosen.js",
                                        "bower_components/angular-farbtastic/angular-farbtastic.js"
                                    ]
                                }
                            ]);
                        }
                    }
                })
                .state("editarUsuarios", {
                    url: "/usuarios/:usuarioId",
                    templateUrl: "views/usuarios-manter.html",
                    resolve: {
                        loadPlugin: function ($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "bower_components/nouislider/jquery.nouislider.css",
                                        "custom_components/farbtastic/farbtastic.css",
                                        "custom_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "custom_components/input-mask/input-mask.min.js",
                                        "bower_components/nouislider/jquery.nouislider.min.js",
                                        "bower_components/moment/min/moment.min.js",
                                        "custom_components/fileinput/fileinput.min.js",
                                        "custom_components/chosen/chosen.jquery.js",
                                        "bower_components/angular-chosen-localytics/chosen.js",
                                        "bower_components/angular-farbtastic/angular-farbtastic.js"
                                    ]
                                }
                            ]);
                        }
                    }
                })
                .state("faturamento", {
                    url: "/faturamento",
                    templateUrl: "views/faturamento.html"
                })
                .state("faturamentoPagamentoCancelado", {
                    url: "/faturamento/pagamentocancelado",
                    templateUrl: "views/pagamentoCancelado.html"
                })                
                .state("faturamentoPagamentoConfirmado", {
                    url: "/faturamento/pagamentoconfirmado",
                    templateUrl: "views/pagamentoConfirmado.html"
                });
        });
})();