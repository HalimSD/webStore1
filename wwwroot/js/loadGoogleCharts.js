google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {
    $.get('GetCategorySold', function (jsonData) {
        let json = jsonData;
        let data = new google.visualization.DataTable(json);

        let option = {
            title: 'Percentage verkoop van elk categorie',
            width: 500,
            height: 400
        };


        //3D Pie Chart:
        option.is3D = true;
        let chart = new google.visualization.PieChart(document.getElementById('chart1'));
        chart.draw(data, option);

    });
    $.get('GetTotalSoldData', function (jsonData) {
        let data = google.visualization.arrayToDataTable(jsonData, false);
        let option = {
            title: "Totaal verkochtte producten sinds begin van het week",
            width: 600,
            height: 400,
            hAxis: {
                title: 'Aantal dagen geleden'
            },
            vAxis: {
                title: 'Aantal verkochtte producten'
            },
        };
        let chart = new google.visualization.LineChart(document.getElementById('chart2'));
        chart.draw(data, option);
    });
}