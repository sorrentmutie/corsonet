window.firstChart = function () {
    console.log("firstChart called");
    var div = document.querySelector('.ct-chart');
    console.log(div);

    var data = {
        // A labels array that can contain any sort of values
        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
        // Our series array that contains series objects or in this case series data arrays
        series: [
            [5, 2, 4, 2, 0]
        ]
    };

    // Create a new line chart object where as first parameter we pass in a selector
    // that is resolving to our chart container element. The Second parameter
    // is the actual data object.
    new Chartist.Line('.ct-chart', data);
}

window.secondChart = function (id) {
    var data = {
        // A labels array that can contain any sort of values
        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
        // Our series array that contains series objects or in this case series data arrays
        series: [
            [5, 2, 4, 2, 0]
        ]
    };

    // Create a new line chart object where as first parameter we pass in a selector
    // that is resolving to our chart container element. The Second parameter
    // is the actual data object.
    new Chartist.Line("#" + id, data);
}


window.thirdChart = function (element, chartType, chartData) {
    //var data = {
    //    // A labels array that can contain any sort of values
    //    labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
    //    // Our series array that contains series objects or in this case series data arrays
    //    series: [
    //        [5, 2, 4, 2, 8], [8, 2, 4, 2, 5]
    //    ]
    //};

    // Create a new line chart object where as first parameter we pass in a selector
    // that is resolving to our chart container element. The Second parameter
    // is the actual data object.
    console.log(chartType);
    console.log(chartData);

    if (chartType === "Bar") {
        new Chartist.Bar(element, chartData);
    } else if (chartType === "Line") {
        new Chartist.Line(element, chartData);

    } else {
        new Chartist.Pie(element, chartData);
    }


    /*new Chartist.Bar(element, data);*/
}





//window.thirdChart = function (element, chartType) {
//    var data = {
//        // A labels array that can contain any sort of values
//        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
//        // Our series array that contains series objects or in this case series data arrays
//        series: [
//            [5, 2, 4, 2, 8],[8,2,4,2,5]
//        ]
//    };

//    // Create a new line chart object where as first parameter we pass in a selector
//    // that is resolving to our chart container element. The Second parameter
//    // is the actual data object.
//    console.log(chartType);

//    if (chartType === "Bar") {
//        new Chartist.Bar(element, data);
//    } else {
//        new Chartist.Line(element, data);
//    }


//    /*new Chartist.Bar(element, data);*/
//}





//window.thirdChart = function (element) {
//    var data = {
//        // A labels array that can contain any sort of values
//        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
//        // Our series array that contains series objects or in this case series data arrays
//        series: [
//            [5, 2, 4, 2, 8]
//        ]
//    };

//    // Create a new line chart object where as first parameter we pass in a selector
//    // that is resolving to our chart container element. The Second parameter
//    // is the actual data object.
//    new Chartist.Bar(element, data);
//}


//window.secondChart = function (element) {
//    var data = {
//        // A labels array that can contain any sort of values
//        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
//        // Our series array that contains series objects or in this case series data arrays
//        series: [
//            [5, 2, 4, 2, 0]
//        ]
//    };

//    // Create a new line chart object where as first parameter we pass in a selector
//    // that is resolving to our chart container element. The Second parameter
//    // is the actual data object.
//    new Chartist.Line(element, data);
//}

window.showChart = function (element, data, type) {
    if (type == 'Line') {
        new Chartist.Line(element, data);
    } else {
        new Chartist.Bar(element, data);
    }

}

window.updateChart = function (element, data, type) {
    if (type == 'Line') {
        new Chartist.Line(element, data);
    } else {
        new Chartist.Bar(element, data);
    }
}