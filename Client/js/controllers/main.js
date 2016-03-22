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

    .controller('resumoGrupoClientesCtrl', function (resumoGrupoClientesService) {

        this.grupos = resumoGrupoClientesService.pegaTodosGrupos();

        this.pegaCorParaGrupo = function () {
            var cores = ["bgm-pink", "bgm-bluegray"];
            return cores[1].toString();
        };
    })




