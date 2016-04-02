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

    // =========================================================================
    // Resumoo grupo
    // =========================================================================
    .controller('resumoGrupoCtrl', function (resumoGrupoService) {

        function aoCompletarSumarioSituacao(grupo) {
            var classeGraficoOk = '.grupo-' + grupo.id + ' .ok-pie';
            var classeGraficoAtencao = '.grupo-' + grupo.id + ' .atencao-pie';
            var classeGraficoCritico = '.grupo-' + grupo.id + ' .critico-pie';
            var classeGraficoInconclusivo = '.grupo-' + grupo.id + ' .inconclusivo-pie';

            $(classeGraficoOk).data('easyPieChart').update(grupo.sumarioSituacao.percentualOk);
            $(classeGraficoAtencao).data('easyPieChart').update(grupo.sumarioSituacao.percentualAtencao);
            $(classeGraficoCritico).data('easyPieChart').update(grupo.sumarioSituacao.percentualCritico);
            $(classeGraficoInconclusivo).data('easyPieChart').update(grupo.sumarioSituacao.percentualInconclusivo);
        }

        this.grupos = resumoGrupoService.pegaTodosGrupos(aoCompletarSumarioSituacao);
    })




