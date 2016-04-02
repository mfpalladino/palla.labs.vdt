sceiAdmin

    .service('scrollService', function() {
        var ss = {};
        ss.malihuScroll = function scrollBar(selector, theme, mousewheelaxis) {
            $(selector).mCustomScrollbar({
                theme: theme,
                scrollInertia: 100,
                axis:'yx',
                mouseWheel: {
                    enable: true,
                    axis: mousewheelaxis,
                    preventDefault: true
                }
            });
        }
        
        return ss;
    })

    .service('growlService', function(){
        var gs = {};
        gs.growl = function(message, type) {
            $.growl({
                message: message
            },{
                type: type,
                allow_dismiss: false,
                label: 'Cancel',
                className: 'btn-xs btn-inverse',
                placement: {
                    from: 'top',
                    align: 'right'
                },
                delay: 2500,
                animate: {
                        enter: 'animated bounceIn',
                        exit: 'animated bounceOut'
                },
                offset: {
                    x: 20,
                    y: 85
                }
            });
        }
        
        return gs;
    })

    .factory('grupoResource', function ($resource, constantsService) {
        return {
            listaGrupos: $resource(constantsService.baseUrl() + 'grupos'),
            sumarioSituacao: $resource(constantsService.baseUrl() + 'grupos/:id/sumariosituacao')
        }
    })

    .service('resumoGrupoService', ['$resource','grupoResource',  function ($resource, grupoResource) {
        this.pegaTodosGrupos = function (aoCompletarSumarioSituacao) {
            return grupoResource.listaGrupos.query(function(grupos) {
                grupos.forEach(function(item) {
                    grupoResource.sumarioSituacao.get({ id: item.id }, function (sumarioSituacao) {
                        item.sumarioSituacao = sumarioSituacao;
                        aoCompletarSumarioSituacao(item);
                    });
                });
            });
        }
    }])
