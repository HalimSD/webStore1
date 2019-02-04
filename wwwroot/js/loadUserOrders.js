import {createPagination} from "./createPagination.js";

function init() {
    // Do GET request to GetData action and pass JSON result to populateTable()
    $.get("/orders/getdata", function (jsonModel) {
        console.log(jsonModel);
        populateTable(jsonModel, false);
    });

    // Setup event handlers
    let filters = ["#filterId", "#filterDate"];
    for (let i in filters) {
        $(filters[i]).on("input", onInputChanged);
    }
    $("#filterStatus").on("change", onInputChanged);
}

function onInputChanged(pageNumber = 1) {
    let noFilters = false;
    let Id = document.getElementById("filterId").value.toString();
    let Date = document.getElementById("filterDate").value.toString();
    
    // Get selected value of select dropdown
    let statusElement = document.getElementById("filterStatus");
    let Status = statusElement.options[statusElement.selectedIndex].value.toString();


    if (Id === "" && Date === "" && Status === "") {
        noFilters = true;
    }

    if (noFilters === false) {
        $.get(
            "/orders/getdatafiltered",
            {
                id: Id,
                date: Date,
                status: Status,
                pageIndex: pageNumber.toString()
            },
            function (data) {
                populateTable(data, true);
            }
        );
    } else {
        $.get("/orders/getdata", {pageIndex: pageNumber.toString()}, function (data) {
            populateTable(data, false);
        });
    }
}

// Creates the options column of a row
function createOptionsColumn(orderId) {
    let tdElement = document.createElement("td");

    // View option
    let aElementView = document.createElement("a");
    let aElementViewTxt = document.createTextNode("Details");
    aElementView.className = "btn btn-primary";
    aElementView.appendChild(aElementViewTxt);
    aElementView.setAttribute("href", "/Orders/Details/" + orderId.toString());

    // Append everything
    tdElement.appendChild(aElementView);
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
        let id = obj.id;


        // Iterate through the object and create td html foreach value
        $.each(obj, function (key, value) {
            if (key === "id" || key === "date" || key === "status") {

                if (key === "date") {
                    value = value.split("T")[0];

                    let select = document.getElementById("filterDate");
                    let option = document.createElement("option");
                    option.value = value;
                    option.innerHTML = value;
                    select.appendChild(option);
                }

                let tdElement = document.createElement("td");
                let txtNode;
                if (key === "status") {
                    txtNode = createBadge(value)
                } else {
                    txtNode = document.createTextNode(value.toString());
                }

                // Append the newly created elements into their respective parent elements
                tdElement.appendChild(txtNode);
                trElement.appendChild(tdElement);
            }
        });

        trElement.appendChild(createOptionsColumn(id));
        tableBody.appendChild(trElement);
    }
    createPagination(jsonModel, onInputChanged);
}

function createBadge(value) {
    let badge = document.createElement("span");
    badge.innerHTML = value;
    switch (value) {
        case "Onderweg":
            badge.className = "badge badge-info";
            break;
        case "Bezorgd":
            badge.className = "badge badge-success";
            break;
        case "In Behandeling":
            badge.className = "badge badge-warning";
            break;
        case "Geannuleerd":
            badge.className = "badge badge-secondary";
            break;
        case "Mislukt":
            badge.className = "badge badge-danger";
    }
    return badge;
}

$(init);