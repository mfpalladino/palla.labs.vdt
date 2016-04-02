sceiAdmin
    .directive('easypieChart', function(){
        return {
            restrict: 'A',
            link: function(scope, element) {
                function easyPieChart(selector, trackColor, scaleColor, barColor, lineWidth, lineCap, size) {
                    $(selector).easyPieChart({
                        trackColor: trackColor,
                        scaleColor: scaleColor,
                        barColor: barColor,
                        lineWidth: lineWidth,
                        lineCap: lineCap,
                        size: size
                    });
                }

                easyPieChart('.ok-pie', 'rgba(255,255,255,0.2)', 'rgba(255,255,255,0.5)', 'rgba(255,255,255,0.7)', 7, 'butt', 148);
                easyPieChart('.atencao-pie', '#eee', '#ccc', '#FFC107', 4, 'butt', 95);
                easyPieChart('.critico-pie', '#eee', '#ccc', 'rgba(226, 48, 48, 0.9)', 4, 'butt', 95);
                easyPieChart('.inconclusivo-pie', '#eee', '#ccc', 'rgba(175, 180, 171, 0.9)', 4, 'butt', 95);
            }
        }
    })