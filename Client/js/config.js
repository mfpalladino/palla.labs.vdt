(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .config(function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise("/home");

            $stateProvider
                .state("home", {
                    url: "/home",
                    templateUrl: "views/home.html",
                    resolve: {
                        loadPlugin: function($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "vendors/bower_components/fullcalendar/dist/fullcalendar.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    insertBefore: "#app-level-js",
                                    files: [
                                        "vendors/sparklines/jquery.sparkline.min.js",
                                        "vendors/bower_components/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js"
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
                        loadPlugin: function($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "vendors/bower_components/nouislider/jquery.nouislider.css",
                                        "vendors/farbtastic/farbtastic.css",
                                        "vendors/bower_components/summernote/dist/summernote.css",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css",
                                        "vendors/bower_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "vendors/input-mask/input-mask.min.js",
                                        "vendors/bower_components/nouislider/jquery.nouislider.min.js",
                                        "vendors/bower_components/moment/min/moment.min.js",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                                        "vendors/bower_components/summernote/dist/summernote.min.js",
                                        "vendors/fileinput/fileinput.min.js",
                                        "vendors/bower_components/chosen/chosen.jquery.js",
                                        "vendors/bower_components/angular-chosen-localytics/chosen.js",
                                        "vendors/bower_components/angular-farbtastic/angular-farbtastic.js"
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
                        loadPlugin: function($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "vendors/bower_components/nouislider/jquery.nouislider.css",
                                        "vendors/farbtastic/farbtastic.css",
                                        "vendors/bower_components/summernote/dist/summernote.css",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css",
                                        "vendors/bower_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "vendors/input-mask/input-mask.min.js",
                                        "vendors/bower_components/nouislider/jquery.nouislider.min.js",
                                        "vendors/bower_components/moment/min/moment.min.js",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                                        "vendors/bower_components/summernote/dist/summernote.min.js",
                                        "vendors/fileinput/fileinput.min.js",
                                        "vendors/bower_components/chosen/chosen.jquery.js",
                                        "vendors/bower_components/angular-chosen-localytics/chosen.js",
                                        "vendors/bower_components/angular-farbtastic/angular-farbtastic.js"
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
                        loadPlugin: function($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "vendors/bower_components/nouislider/jquery.nouislider.css",
                                        "vendors/farbtastic/farbtastic.css",
                                        "vendors/bower_components/summernote/dist/summernote.css",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css",
                                        "vendors/bower_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "vendors/input-mask/input-mask.min.js",
                                        "vendors/bower_components/nouislider/jquery.nouislider.min.js",
                                        "vendors/bower_components/moment/min/moment.min.js",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                                        "vendors/bower_components/summernote/dist/summernote.min.js",
                                        "vendors/fileinput/fileinput.min.js",
                                        "vendors/bower_components/chosen/chosen.jquery.js",
                                        "vendors/bower_components/angular-chosen-localytics/chosen.js",
                                        "vendors/bower_components/angular-farbtastic/angular-farbtastic.js"
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
                        loadPlugin: function($ocLazyLoad) {
                            return $ocLazyLoad.load([
                                {
                                    name: "css",
                                    insertBefore: "#app-level",
                                    files: [
                                        "vendors/bower_components/nouislider/jquery.nouislider.css",
                                        "vendors/farbtastic/farbtastic.css",
                                        "vendors/bower_components/summernote/dist/summernote.css",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css",
                                        "vendors/bower_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "vendors/input-mask/input-mask.min.js",
                                        "vendors/bower_components/nouislider/jquery.nouislider.min.js",
                                        "vendors/bower_components/moment/min/moment.min.js",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                                        "vendors/bower_components/summernote/dist/summernote.min.js",
                                        "vendors/fileinput/fileinput.min.js",
                                        "vendors/bower_components/chosen/chosen.jquery.js",
                                        "vendors/bower_components/angular-chosen-localytics/chosen.js",
                                        "vendors/bower_components/angular-farbtastic/angular-farbtastic.js"
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
                                        "vendors/bower_components/nouislider/jquery.nouislider.css",
                                        "vendors/farbtastic/farbtastic.css",
                                        "vendors/bower_components/summernote/dist/summernote.css",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css",
                                        "vendors/bower_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "vendors/input-mask/input-mask.min.js",
                                        "vendors/bower_components/nouislider/jquery.nouislider.min.js",
                                        "vendors/bower_components/moment/min/moment.min.js",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                                        "vendors/bower_components/summernote/dist/summernote.min.js",
                                        "vendors/fileinput/fileinput.min.js",
                                        "vendors/bower_components/chosen/chosen.jquery.js",
                                        "vendors/bower_components/angular-chosen-localytics/chosen.js",
                                        "vendors/bower_components/angular-farbtastic/angular-farbtastic.js"
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
                                        "vendors/bower_components/nouislider/jquery.nouislider.css",
                                        "vendors/farbtastic/farbtastic.css",
                                        "vendors/bower_components/summernote/dist/summernote.css",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css",
                                        "vendors/bower_components/chosen/chosen.min.css"
                                    ]
                                },
                                {
                                    name: "vendors",
                                    files: [
                                        "vendors/input-mask/input-mask.min.js",
                                        "vendors/bower_components/nouislider/jquery.nouislider.min.js",
                                        "vendors/bower_components/moment/min/moment.min.js",
                                        //"vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                                        "vendors/bower_components/summernote/dist/summernote.min.js",
                                        "vendors/fileinput/fileinput.min.js",
                                        "vendors/bower_components/chosen/chosen.jquery.js",
                                        "vendors/bower_components/angular-chosen-localytics/chosen.js",
                                        "vendors/bower_components/angular-farbtastic/angular-farbtastic.js"
                                    ]
                                }
                            ]);
                        }
                    }
                });
        });
})();