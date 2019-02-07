import {createPagination} from "./createPagination.js";

function init() {
    google.charts.load('current', {'packages': ['corechart']});
    google.charts.setOnLoadCallback(function () {
        drawCategoryChart();
        drawTotalProductsChart();

        // Add event handlers
        let totalSoldDropdown = document.getElementById("totalChartRange");
        totalSoldDropdown.onchange = function (ev) {
            console.log("Executing event handler!");
            let val = totalSoldDropdown.options[totalSoldDropdown.selectedIndex].value;
            drawTotalProductsChart(val);
            ev.stopImmediatePropagation();
        }
        let categorySoldDropdown = document.getElementById("categoryChartRange");
        categorySoldDropdown.onchange = function (ev) {
            console.log("Executing event handler!");
            let val = categorySoldDropdown.options[categorySoldDropdown.selectedIndex].value;
            drawCategoryChart(val);
            ev.stopImmediatePropagation();
        }
    });

    // Do GET request to GetData action and pass JSON result to populateTable()
    onInputChanged();

    // Setup event handlers
    let filters = ["#filterId", "#filterName", "#filterStock", "#filterCategory"];
    for (let i in filters) {
        $(filters[i]).on("input", onInputChanged);
    }
}

function enumDefinition(enumValue) {
    switch (enumValue) {
        case "Week":
            return "1 Week";
        case "TwoWeeks":
            return "2 Weken";
        case "ThreeWeeks":
            return "3 Weken";
        case "Month":
            return "1 Maand";
        case "ThreeMonths":
            return "3 Maanden";
        case "SixMonths":
            return "6 Maanden";
        case "Year":
            return "1 Jaar";
        case "All":
            return "Alles";
        default:
            return enumValue;
    }
}

// Will only create dropdown if it hasn't already been created!
function updateRangeDropdown(ranges, selectElement, defaultOption = "Week") {

    // Check if dropdown is already populated
    if (selectElement.firstChild) return;

    // Add the range options
    ranges.forEach(function (element) {
        let option = document.createElement("option");
        option.value = element;
        option.innerText = enumDefinition(element);
        selectElement.append(option);
        if (element === defaultOption) {
            selectElement.value = element;
        }
    })
}

function drawCategoryChart(range = "All") {
    $.get("Statistics/GetCategorySold/" + range, function (jsonData) {
        console.log("Statistics/GetCategorySold/" + range);
        let dataArray = [];
        let isFirst = true;
        jsonData.data.forEach(function (element) {
            let key = element[0];
            let value = element[1];
            if (isFirst) {
                isFirst = false;
            } else {
                value = parseInt(value);
            }
            dataArray.push([key, value]);
        });
        let data = new google.visualization.arrayToDataTable(dataArray);
        let option = {
            title: 'Percentage verkoop van elk categorie',
            width: 500,
            height: 400
        };


        //3D Pie Chart:
        option.is3D = true;
        let chart = new google.visualization.PieChart(document.getElementById('chart1'));
        chart.draw(data, option);
        updateRangeDropdown(jsonData.ranges, document.getElementById("categoryChartRange"), "All");
    });
}

function drawTotalProductsChart(range = "") {
    $.get("Statistics/GetTotalSoldData/" + range, function (jsonData) {
        let dataArray = [];
        let isFirst = true;
        jsonData.data.forEach(function (element) {
            let key = element[0];
            let value = element[1];
            if (isFirst) {
                isFirst = false;
            } else {
                value = parseInt(value);
            }
            dataArray.push([key, value]);
        });
        let data = google.visualization.arrayToDataTable(dataArray, false);
        let option = {
            title: "Totaal verkochtte producten",
            width: 650,
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
        updateRangeDropdown(jsonData.ranges, document.getElementById("totalChartRange"));
    });
}

// LOAD PRODUCTS TABLE

function onInputChanged(pageNumber = 1) {
    let noFilters = false;
    let Id = document.getElementById("filterId").value.toString();
    let Name = document.getElementById("filterName").value.toString();
    let Stock = document.getElementById("filterStock").value.toString();
    let Category = document.getElementById("filterCategory").value.toString();


    if (noFilters == false) {
        $.get(
            "/admin/statistics/getdatafiltered",
            {
                id: Id,
                name: Name,
                category: Category,
                stock: Stock,
                pageIndex: pageNumber.toString()
            },
            function (data) {
                populateTable(data, true);
            }
        );
    }
}

// Creates the options column of a row
function createOptionsColumn(productId) {
    let tdElement = document.createElement("td");

    // Delete option
    let aElementDelete = document.createElement("a");
    let aElementDeleteTxt = document.createTextNode("Verwijderen");
    aElementDelete.appendChild(aElementDeleteTxt);
    aElementDelete.setAttribute("href", "/Admin/ProductList/ConfirmDelete?id=" + productId.toString());

    // Edit option
    let aElementEdit = document.createElement("a");
    let aElementEditTxt = document.createTextNode("Bewerken");
    aElementEdit.appendChild(aElementEditTxt);
    aElementEdit.setAttribute("href", "/Admin/EditProduct/Index?id=" + productId.toString());

    // Visit page option
    let aElementVisit = document.createElement("a");
    let aElementVisitTxt = document.createTextNode("Bekijken");
    aElementVisit.appendChild(aElementVisitTxt);
    aElementVisit.setAttribute("href", "/ViewProduct/Index/" + productId.toString());

    // Append everything
    tdElement.appendChild(aElementDelete);
    tdElement.appendChild(document.createTextNode(" | "));
    tdElement.appendChild(aElementEdit);
    tdElement.appendChild(document.createTextNode(" | "));
    tdElement.appendChild(aElementVisit);
    return tdElement;
}

function populateTable(jsonModel, filtered) {
    // Get the data from the page model
    let data = jsonModel.data;
    // Get the tbody element by using its ID
    let tableBody = document.getElementById("tableBody");
    // Clear the table of any previous rows
    while (tableBody.firstChild) {
        tableBody.removeChild(tableBody.firstChild);
    }

    // Loop through the JSON Array
    for (let i in data) {
        // Current obj in de array
        let obj = data[i];
        // tr html element represents a row
        let trElement = document.createElement("tr");
        // Product ID
        let id = -1;

        // Iterate through the object and create td html foreach value
        $.each(obj, function (key, value) {
            let tdElement = document.createElement("td");
            let txtNode;
            if (key === "discountedPrice" || key === "price") return;

            if (key === "id") {
                tdElement.setAttribute("width", "5%");
                id = value;
            }
            txtNode = document.createTextNode(value.toString());
            // Append the newly created elements into their respective parent elements
            tdElement.appendChild(txtNode);
            trElement.appendChild(tdElement);
        });


        trElement.appendChild(createOptionsColumn(id));
        tableBody.appendChild(trElement);
    }
    createPagination(jsonModel, onInputChanged);
}

$(init);