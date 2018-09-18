
$(function () {

    var _par1 = $("#id").val();

    $.ajax({
        url: '/adminCurrency/CurrencyChartView',
        data: { currencyId: _par1 },
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
            $('#currencyChartDetail').highcharts({
                title: {
                    text: result.Title,
                    x: -20 //center
                },
                subtitle: {
                    text: 'نمودار 50 روزه',
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
                    valueSuffix: 'ریال'
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