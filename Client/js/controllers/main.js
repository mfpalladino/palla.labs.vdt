sceiAdmin
    .controller('sceiAdminCtrl', function($timeout, $state, $scope, growlService) {

        if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
            angular.element('html').addClass('ismobile');
        }

        this.layoutType = "1"; //layout com o menu encaixado à esquerda

        this.$state = $state;

        this.currentSkin = 'orange';

        this.skinList = [
            'lightblue',
            'bluegray',
            'cyan',
            'teal',
            'green',
            'orange',
            'blue',
            'purple'
        ];
    })


    // =========================================================================
    // Header
    // =========================================================================
    .controller('headerCtrl', function() {
    })



