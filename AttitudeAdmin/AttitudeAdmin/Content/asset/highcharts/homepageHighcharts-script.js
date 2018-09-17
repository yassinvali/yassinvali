
$(function () {

    $(document).ready(function () {
        var _par1 = $("#SelectChartCurrency").val();
        var _from = $("#currencyFromDate").val();
        var _to = $("#currencyToDate").val();
        $.ajax({
            url: '/home/CurrencyChartView',
            data: { currencyId: _par1, from: _from, to: _to },
            success: function (result) {
                var _cate = [];
                var _data1 = [];
                var _data2 = [];
                $.each(result.categories, function (index, value) {
                    _cate.push(value);
                });
                $.each(result.dataSale, function (index, value) {
                    _data1.push(parseInt(value));
                });
                $.each(result.datasBuy, function (index, value) {
                    _data2.push(parseInt(value));
                });

                $('#currencyChart').highcharts({
                    title: {
                        text: result.Title,
                        x: -20 //center
                    },
					credits: {
						enabled: false
					},
                    subtitle: {
                        text: result.Subtext,
                        x: -20
                    },
                    xAxis: {
                        categories: _cate
                    },
                    yAxis: {
                        title: {
                            text: 'مبلغ'
                        },
                        plotLines: [
                            {
                                value: 0,
                                width: 1,
                                color: '#808080'
                            }
                        ]
                    },
                    tooltip: {
                        valueSuffix: 'تومان',
                        shared: 1,
                        crosshairs: 1,
                        formatter: function () {
                            
                            var tooltipMarkup = "";
                            for (var index = 0; index < this.points.length; index += 1) {

                                if (this.points[index].series.color === "#7cb5ec") {
                                    tooltipMarkup += '<div><span style="font-size: 11px; color:' + this.points[index].series.color + '">' + this.points[index].series.name + '</span>' + ': <b style="font-size: 11px;color:' + this.points[index].series.color + '">' + this.points[index].y + ' تومان' + ' </b><text style="color: transparent;">I</text><br /></div>';
                                }
                                else {
                                    tooltipMarkup += '<div><span style="color:' + this.points[index].series.color + '">' + this.points[index].series.name + '</span>' + ': <b style="color: #222">' + this.points[index].y + ' تومان' + ' </b></div><br class=\'separator\' />';
                                }
                            }

                            return tooltipMarkup;
                        }
                    },
                    legend: {
                        layout: 'vertical',
                        align: 'right',
                        verticalAlign: 'middle',
                        borderWidth: 0
                    },
                    series: [
                        {
                            name: 'نمودار خرید ',
                            data: _data2
                        }, {
                            name: 'نمودار فروش',
                            data: _data1
                        },
                    ]

                });

                $('#currencyChartThumbnail').highcharts({
                    title: {
                        text:''
                    },
                    credits: {
                        enabled: false
                    },
                    subtitle: {
                        text: result.Subtext,
                        x: -20
                    },
                    xAxis: {
                        labels: {
                            enabled: false
                        },
                        title: {
                            text: null
                        },
                        categories: _cate
                    },
                    yAxis: {
                        endOnTick: false,
                        startOnTick: false,
                        labels: {
                            enabled: false
                        },
                        title: {
                            text: 'مبلغ'
                        },
                        plotLines: [
                            {
                                value: 0,
                                width: 1,
                                color: '#808080'
                            }
                        ]
                    },
                    tooltip: {
                        valueSuffix: 'تومان',
                        shared: 1,
                        crosshairs: 1,
                        formatter: function () {

                            var tooltipMarkup = "";
                            for (var index = 0; index < this.points.length; index += 1) {

                                if (this.points[index].series.color === "#7cb5ec") {
                                    tooltipMarkup += '<div><span style="font-size: 11px; color:' + this.points[index].series.color + '">' + this.points[index].series.name + '</span>' + ': <b style="font-size: 11px;color:' + this.points[index].series.color + '">' + this.points[index].y + ' تومان' + ' </b><text style="color: transparent;">I</text><br /></div>';
                                }
                                else {
                                    tooltipMarkup += '<div><span style="color:' + this.points[index].series.color + '">' + this.points[index].series.name + '</span>' + ': <b style="color: #222">' + this.points[index].y + ' تومان' + ' </b></div><br class=\'separator\' />';
                                }
                            }

                            return tooltipMarkup;
                        }
                    },
                    legend: {
                        enabled: false
                    },
                    series: [
                        {
                            name: 'نمودار خرید ',
                            data: _data2
                        }, {
                            name: 'نمودار فروش',
                            data: _data1
                        },
                    ]

                });
            }
        });
    });

    $("#btnCurrencyChart").click(function () {

        var _par1 = $("#SelectChartCurrency option:selected").val();
        var _from = $("#currencyFromDate").val();
        var _to = $("#currencyToDate").val();
        $.ajax({
            url: '/home/CurrencyChartView',
            data: { currencyId: _par1, from: _from, to: _to },
            success: function (result) {
                var _cate = [];
                var _data1 = [];
                var _data2 = [];
                $.each(result.categories, function (index, value) {
                    _cate.push(value);
                });
                $.each(result.dataSale, function (index, value) {
                    _data1.push(parseInt(value));
                });
                $.each(result.datasBuy, function (index, value) {
                    _data2.push(parseInt(value));
                });


                $('#currencyChart').highcharts({
                    title: {
                        text: result.Title,
                        x: -20 //center
                    },
                   credits: {
						enabled: false
					}, subtitle: {
                        text: result.Subtext,
                        x: -20
                    },
                    xAxis: {
                        categories: _cate
                    },
                    yAxis: {
                        title: {
                            text: 'مبلغ'
                        },
                        plotLines: [
                            {
                                value: 0,
                                width: 1,
                                color: '#808080'
                            }
                        ]
                    },
                    tooltip: {
                        shared: 1,
                        crosshairs: 1, valueSuffix: 'تومان',
                        formatter: function () {
                            
                    var tooltipMarkup = "";
                    for (var index = 0; index < this.points.length; index += 1) {

                        if (this.points[index].series.color === "#7cb5ec") {
                            tooltipMarkup += '<div><span style="font-size: 11px; color:' + this.points[index].series.color + '">' + this.points[index].series.name + '</span>' + ': <b style="font-size: 11px;color:' + this.points[index].series.color + '">' + this.points[index].y + ' تومان' + ' </b><text style="color: transparent;">I</text><br /></div>';
                        }
                        else {
                            tooltipMarkup += '<div><span style="color:' + this.points[index].series.color + '">' + this.points[index].series.name + '</span>' + ': <b style="color: #222">' + this.points[index].y + ' تومان' + ' </b></div><br class=\'separator\' />';
                        }
                    }

                    return tooltipMarkup;
                }
                    },
                    legend: {
                        layout: 'vertical',
                        align: 'right',
                        verticalAlign: 'middle',
                        borderWidth: 0
                    },
                    series: [
                        {
                            name: 'نمودار خرید',
                            data: _data2
                        }, {
                            name: 'نمودار فروش',
                            data: _data1
                        },
                    ]

                });
            }
        });
    });

    $("#btnCoinChart").click(function () {

        var _par1 = $("#SelectChartCoin option:selected").val();
        var _from = $("#coinFromDate").val();
        var _to = $("#coinToDate").val();
        $.ajax({
            url: '/home/CoinChartView',
            data: { coinId: _par1, from: _from, to: _to },
            success: function (result) {
                var _cate = [];
                var _data1 = [];
                var _data2 = [];
                $.each(result.categories, function (index, value) {
                    _cate.push(value);
                });
                $.each(result.dataSale, function (index, value) {
                    _data1.push(parseInt(value));
                });
                $.each(result.datasBuy, function (index, value) {
                    _data2.push(parseInt(value));
                });
                $('#coinChart').highcharts({
                    title: {
                        text: result.Title,
                        x: -20 //center
                    },
                    credits: {
						enabled: false
					},subtitle: {
                        text: result.Subtext,
                        x: -20
                    },
                    xAxis: {
                        categories: _cate
                    },
                    yAxis: {
                        title: {
                            text: 'مبلغ'
                        },
                        plotLines: [
                            {
                                value: 0,
                                width: 1,
                                color: '#808080'
                            }
                        ]
                    },
                    tooltip: {
                        shared: 1,
                        crosshairs: 1,
                        valueSuffix: 'تومان',
                        formatter: function () {

                            var tooltipMarkup = "";
                            for (var index = 0; index < this.points.length; index += 1) {

                                if (this.points[index].series.color === "#7cb5ec") {
                                    tooltipMarkup += '<div><span style="font-size: 11px; color:' + this.points[index].series.color + '">' + this.points[index].series.name + '</span>' + ': <b style="font-size: 11px;color:' + this.points[index].series.color + '">' + this.points[index].y + ' تومان' + ' </b><text style="color: transparent;">I</text><br /></div>';
                                }
                                else {
                                    tooltipMarkup += '<div><span style="color:' + this.points[index].series.color + '">' + this.points[index].series.name + '</span>' + ': <b style="color: #222">' + this.points[index].y + ' تومان' + ' </b></div><br class=\'separator\' />';
                                }
                            }

                            return tooltipMarkup;
                        }
                    },
                    legend: {
                        layout: 'vertical',
                        align: 'right',
                        verticalAlign: 'middle',
                        borderWidth: 0
                    },
                    series: [
                        {
                            name: 'نمودار فروش',
                            data: _data2
                        }, {
                            name: 'نمودار خرید',
                            data: _data1
                        },
                    ]

                });
            }
        });
    });

    $("#btnOrderChart").click(function () {

        var _par1 = $("#SelectChartOrder option:selected").val();
        var _from = $("#orderFromDate").val();
        var _to = $("#orderToDate").val();
        $.ajax({
            url: '/home/OrderChartView',
            data: { orderId: _par1, from: _from, to: _to },
            success: function (result) {
                var _cate = [];
                var _data1 = [];
                $.each(result.categories, function (index, value) {
                    _cate.push(value);
                });
                $.each(result.dataSale, function (index, value) {
                    _data1.push(parseInt(value));
                });
                $('#orderChart').highcharts({
                    title: {
                        text: result.Title,
                        x: -20 //center
                    },
                    credits: {
						enabled: false
					},subtitle: {
                        text: result.Subtext,
                        x: -20
                    },
                    xAxis: {
                        categories: _cate
                    },
                    yAxis: {
                        title: {
                            text: 'مبلغ'
                        },
                        plotLines: [
                            {
                                value: 0,
                                width: 1,
                                color: '#808080'
                            }
                        ]
                    },
                    tooltip: {
                      shared: 1,
                      crosshairs: 1,
                      valueSuffix: 'تومان',
                        formatter: function () {

                            var tooltipMarkup = "";
                            for (var index = 0; index < this.points.length; index += 1) {

                                if (this.points[index].series.color === "#7cb5ec") {
                                    tooltipMarkup += '<div><span style="font-size: 11px; color:' + this.points[index].series.color + '">' + this.points[index].series.name + '</span>' + ': <b style="font-size: 11px;color:' + this.points[index].series.color + '">' + this.points[index].y + ' تومان' + ' </b><text style="color: transparent;">I</text><br /></div>';
                                }
                                else {
                                    tooltipMarkup += '<div><span style="color:' + this.points[index].series.color + '">' + this.points[index].series.name + '</span>' + ': <b style="color: #222">' + this.points[index].y + 'تومان' + ' </b></div><br class=\'separator\' />';
                                }
                            }

                            return tooltipMarkup;
                        }
                    },
                    legend: {
                        layout: 'vertical',
                        align: 'right',
                        verticalAlign: 'middle',
                        borderWidth: 0
                    },
                    series: [
                         {
                             name: 'نمودار فروش',
                             data: _data1
                         },
                    ]

                });
            }
        });
    });
});

