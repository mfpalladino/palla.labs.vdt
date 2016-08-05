(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("growlService", function() {
            var gs = {};

            gs.growlError = function(message) {
                return gs.growl(message, "danger", "animated bounceIn", "animated bounceOut");
            }

            gs.growlSuccess = function (message) {
                return gs.growl(message, "success", "animated bounceIn", "animated bounceOut");
            }

            gs.growlWelcome = function (message) {
                return gs.growl(message, "inverse", "animated flipInY", "animated flipOutY");
            }

            gs.growl = function (message, type, animatedEnter, animatedExit) {
                $.growl({
                    message: message
                }, {
                    type: type,
                    allow_dismiss: false,
                    label: "Cancel",
                    className: "btn-xs btn-inverse",
                    placement: {
                        from: "top",
                        align: "right"
                    },
                    delay: 2500,
                    animate: {
                        enter: animatedEnter,
                        exit: animatedExit
                    },
                    offset: {
                        x: 20,
                        y: 85
                    }
                });
            }

            return gs;
        });
})();

