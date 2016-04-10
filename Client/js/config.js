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
                });
        });
})();