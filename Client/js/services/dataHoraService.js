(function() {
    "use strict";

    angular
        .module("sceiAdmin")
        .service("dataHoraService", [
            function() {
                this.unixDateToDate = function(unixDate) {
                    return new Date(unixDate * 1000);
                };

                this.dateToUnixDate = function(date) {
                    return Date.parse(date) / 1000;
                };
            }
        ]);
})();

