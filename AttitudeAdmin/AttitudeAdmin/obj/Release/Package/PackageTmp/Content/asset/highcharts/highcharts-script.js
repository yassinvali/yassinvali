var isIE = 0;
if (window.navigator.userAgent.indexOf("MSIE")) {
    isIE = 1;
}
$(function () {
    $('#coinChart').highcharts({
        chart: {
            zoomType: 'none',
            backgroundColor: '#fff',
            plotBackgroundImage: 'image/logo-chart.png',
            borderWidth: 0,
            plotBackgroundColor: '#fff',
            plotShadow: false,
            plotBorderWidth: 0
        },
        colors: ['#999', '#0277BD', '#00CCFF'],
        exporting: {
            buttons: {
                contextButtons: {
                    enabled: false,
                    menuItems: null
                }
            },
            enabled: false
        },
        title: {
            text: 'قیمت تمام سکه بهار آزادی - بازار تهران'
        },
        credits: {
            enabled: false
        },
        xAxis: {
            title: {
                text: 'از تاریخ 1395/1/19 تا 1395/2/17'
            },
            categories:  ["1395/1/19","1395/1/20","1395/1/21","1395/1/22","1395/1/23","1395/1/24","1395/1/25","1395/1/26","1395/1/27","1395/1/28","1395/1/29","1395/1/30","1395/1/31","1395/2/1","1395/2/2","1395/2/3","1395/2/4","1395/2/5","1395/2/6","1395/2/7","1395/2/8","1395/2/9","1395/2/10","1395/2/11","1395/2/12","1395/2/13","1395/2/14","1395/2/15","1395/2/16","1395/2/17"],

            labels: {
                enabled: false
                
            },
            tickmarkPlacement: "on"
        },
                yAxis: [{ // Primary yAxis
                    gridLineColor: '#EEE',
                    labels: {
                        format: '{value}',
                        style: {
                        }
                    },
                    title: {
                        text: null,
                        style: {
                        }
                    },
                    max: 10495950.0000000,
                    min: 10019050.0000000,
                    opposite: false,
                }, { // Secondary yAxis
                    gridLineWidth: 0,
                    title: {
                        text: null,
                        style: {
                        }
                    },
                    max: 10495950.0000000,
                    min: 10019050.0000000,
                    labels: {
                        enabled: false,
                        format: '{value}',
                        style: {
                        }
                    }

                }, { // Tertiary yAxis
                    gridLineWidth: 0,
                    title: {
                        text: null,
                        style: {
                            //color: Highcharts.getOptions().colors[1]
                        }
                    },
                    labels: {
                        enabled: false,

                        //format: '{value}',
                        style: {
                            //color: Highcharts.getOptions().colors[1]
                        }
                    },
                    max: 10495950.0000000,
                    min: 10019050.0000000,
                    opposite: false
                }],
                tooltip: 
                {
                    shared:  1,
                    crosshairs: 1,
                    formatter: function () {
                        if (!isIE)
                        {
                            var points = this.points;
                            var pointsLength = points.length;
                            var tooltipMarkup = pointsLength ? '<span style="font-size: 10px">' + points[0].key + '</span><br/>' : '';
                            var index;
                            for(index = 0; index < pointsLength; index += 1) {
                                if (points[index].series.color == "#0277BD")
                                {
                                    tooltipMarkup += '<span style="color:' + points[index].series.color + '">' + points[index].series.name+'</span>' + ': <b style="color: #222">' + points[index].y  +' ریال'+ ' </b><br/>';
                                }
                                else
                                {
                                    tooltipMarkup += '<span style="font-size: 11px; color:' + points[index].series.color + '">' + points[index].series.name+'</span>' + ': <b style="font-size: 11px;color:' + points[index].series.color + '">' + points[index].y  +' ریال'+ ' </b><br/>';

                                }
                            }
                            return tooltipMarkup;
                        }
                        else
                        {
                            var points = this.points;
                            var pointsLength = points.length;
                            var tooltipMarkup = pointsLength ? '<span style="width: 150px; font-size: 10px">' + points[0].key + '</span><br/>' : '';
                            for(index = 0; index < pointsLength; index += 1) {
                                if (points[index].series.color == "#0277BD")
                                {
                                    tooltipMarkup += '<div><span style="color:' + points[index].series.color + '">' + points[index].series.name+'</span>' + ': <b style="color: #222">' + points[index].y  +' ریال'+ ' </b></div><br class=\'separator\' />';
                                }
                                else
                                {
                                    tooltipMarkup += '<div><span style="font-size: 11px; color:' + points[index].series.color + '">' + points[index].series.name+'</span>' + ': <b style="font-size: 11px;color:' + points[index].series.color + '">' + points[index].y  +' ریال'+ ' </b><text style="color: transparent;">I</text><br /></div>';

                                }
                            }
                            return tooltipMarkup;
                        }

                    }
                },
                legend: {
                    layout: 'horizontal',
                    align: 'center',
                    x: 0,
                    verticalAlign: 'bottom',
                    y: 0,
                    floating: false,
                    backgroundColor: '#fff',
                    borderWidth: 0,
                    borderRadius: 0
                },
                series: [
                {
                    name: 'ماه  قبل',
                    type: 'spline',
                    yAxis: 2,
                    data: [10170000.0000,10140000.0000,10110000.0000,10110000.0000,10100000.0000,10100000.0000,10155000.0000,10085000.0000,10040000.0000,10150000.0000,10150000.0000,10150000.0000,10150000.0000,10150000.0000,10150000.0000,10150000.0000,10150000.0000,10150000.0000,10125000.0000,10070000.0000,10080000.0000,10115000.0000,10180000.0000,10180000.0000,10180000.0000,10200000.0000,10180000.0000,10155000.0000,10270000.0000,10270000.0000],
                    marker: {
                        enabled: false,
                        states: {
                            hover: {
                                lineWidth: 1,
                                lineColor: null,
                                radius: 4,
                                symbol: 'circle'
                            }
                        }
                    },
                    dashStyle: 'shortdot',
                    tooltip: {
                        valueSuffix: ' ریال'
                    }

                }, {
                    name: 'ماه  جاری',
                    type: 'spline',
                    data: [10215000.0000,10215000.0000,10325000.0000,10325000.0000,10395000.0000,10425000.0000,10340000.0000,10250000.0000,10250000.0000,10275000.0000,10275000.0000,10270000.0000,10285000.0000,10280000.0000,10280000.0000,10280000.0000,10195000.0000,10225000.0000,10220000.0000,10230000.0000,10290000.0000,10305000.0000,10305000.0000,10465000.0000,10470000.0000,10475000.0000,10430000.0000,10345000.0000,10345000.0000,10345000.0000],
                    marker: {
                        enabled: 1,
                        lineWidth: 1,
                        lineColor: null,
                        radius: 2,
                        symbol: 'circle',
                        states: {
                            hover: {
                                lineWidth: 1,
                                lineColor: null,
                                radius: 3,
                                symbol: 'circle'
                            }   
                        }
                    },
                    tooltip: {
                        valueSuffix: ' ریال'
                        
                    }
                }]
            });
});