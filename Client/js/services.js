sceiAdmin

    .service('messageService', ['$resource', function($resource){
        this.getMessage = function(img, user, text) {
            var gmList = $resource("data/messages-notifications.json");
            
            return gmList.get({
                img: img,
                user: user,
                text: text
            });
        }
    }])
    

    // =========================================================================
    // Malihu Scroll - Custom Scroll bars
    // =========================================================================
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


    //==============================================
    // BOOTSTRAP GROWL
    //==============================================

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

    .factory('grupoResource', function($resource) {
        return {
            listaGrupos: $resource('http://localhost:52300/grupos'),
            sumarioSituacao: $resource('http://localhost:52300/grupos/:id/sumariosituacao')
        }
    })

    .service('resumoGrupoClientesService', ['$resource','grupoResource',  function ($resource, grupoResource) {

        this.pegaTodosGrupos = function () {
            return grupoResource.listaGrupos.query(function(grupos) {
                grupos.forEach(function(item) {
                    grupoResource.sumarioSituacao.get({ id: item.id }, function (sumarioSituacao) {
                        item.sumarioSituacao = sumarioSituacao;
                    });
                });
            });
        }
    }])
