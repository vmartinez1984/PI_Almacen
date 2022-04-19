var url;

url = "/Home/ActivitySummary";
fetch(url)
    .then(response => {
        if (response.ok) {
            return response.json();
        }
    })
    .then(response => {
        //console.log(response);
        response.forEach(element => {
            var labels;
            var data;
            var colors;

            labels = getLabels(element);
            data = getData(element);
            colors = getColors(element);

            buildChart("chart_" + element.id, labels, data, colors);
        });
    });

function getLabels(activitySummary) {
    var labels;

    labels = new Array();
    activitySummary.listRowStatus.forEach(element => {
        labels.push(element.name);
    });

    return labels;
}

function getData(activitySummary) {
    var data;

    data = new Array();
    activitySummary.listRowStatus.forEach(element => {
        data.push(element.total);
    });

    return data;
}

function getColors(activitySummary) {
    var data;

    data = new Array();
    activitySummary.listRowStatus.forEach(element => {
        data.push(element.color);
    });

    return data;
}

function buildChart(chartId, labels, data, colors) {
    var ctx = document.getElementById(chartId);
    var myPieChart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: colors,
                hoverBackgroundColor: colors,
                hoverBorderColor: "rgba(234, 236, 244, 1)",
            }],
        },
        options: {
            maintainAspectRatio: false,
            tooltips: {
                backgroundColor: "rgb(255,255,255)",
                bodyFontColor: "#858796",
                borderColor: '#dddfeb',
                borderWidth: 1,
                xPadding: 15,
                yPadding: 15,
                displayColors: false,
                caretPadding: 10,
            },
            legend: {
                display: false
            },
            cutoutPercentage: 80,
        },
    });
}