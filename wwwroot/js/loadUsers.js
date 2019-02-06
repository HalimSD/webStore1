import { createPagination } from "./createPagination.js";

function init() {
    // Do GET request to GetData action and pass JSON result to populateTable()
    $.get("/usermanagement/getusersdata", function (jsonModel) {
        populateTable(jsonModel, false);
    });

    // Setup event handlers
    let filters = ["#filterId", "#filterEmail", "#filterRole"];
    for (let i in filters) {
        $(filters[i]).on("input", onInputChanged);
    }
}

function onInputChanged(pageNumber=1) {
    let noFilters = false;
    let Id = document.getElementById("filterId").value.toString();
    let Email = document.getElementById("filterEmail").value.toString();
    let Role = document.getElementById("filterRole").value.toString();

    if (Id === "" && Email === "" && Role === "") {
        noFilters = true;
    }

    if (noFilters === false) {
        $.get(
            "/usermanagement/GetUsersDataFiltered",
            {
                id : Id,
                email : Email,
                role : Role,
                pageIndex : pageNumber.toString()
            },
            function (data) {
                populateTable(data, true);
            }
        );
    } else {
        $.get("/usermanagement/getusersdata", {pageIndex : pageNumber.toString()}, function (data) {
            populateTable(data, false);
        });
    }
}

// Creates the options column of a row
function createOptionsColumn(userId) {
    let tdElement = document.createElement("td");
    
    let rootDiv = document.createElement("div");
    let button = document.createElement("button");
    button.className = "btn btn-secondary dropdown-toggle";
    button.type = "button";
    button.id = "dropdownMenuButton";
    button.setAttribute("data-toggle","dropdown");
    button.innerText = "Opties";
    tdElement.appendChild(rootDiv);
    rootDiv.appendChild(button);
    
    
    let optionsDiv = document.createElement("div");
    optionsDiv.className = "dropdown-menu";
    rootDiv.appendChild(optionsDiv);
    
    let addRoleOption = document.createElement("a");
    addRoleOption.className = "dropdown-item";
    addRoleOption.href = "/UserManagement/AddRole/" + userId;
    addRoleOption.innerText = "Voeg rol toe";
    optionsDiv.appendChild(addRoleOption);

    let updateInfoOption = document.createElement("a");
    updateInfoOption.className = "dropdown-item";
    updateInfoOption.href = "/UserManagement/UpdateInfoAdmin/" + userId;
    updateInfoOption.innerText = "Bewerken";
    optionsDiv.appendChild(updateInfoOption);

    let deleteUserOption = document.createElement("a");
    deleteUserOption.className = "dropdown-item";
    deleteUserOption.href = "/UserManagement/DeleteUser/" + userId;
    deleteUserOption.innerText = "Verwijderen";
    optionsDiv.appendChild(deleteUserOption);

    let resetPasswordOption = document.createElement("a");
    resetPasswordOption.className = "dropdown-item";
    resetPasswordOption.href = "/UserManagement/ResetUserPassword/" + userId;
    resetPasswordOption.innerText = "Wachtwoord resetten";
    optionsDiv.appendChild(resetPasswordOption);
    
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
            if (key === "discountedPrice" && value == "-1") {
                txtNode = document.createTextNode("Geen Korting");
            }
            else {
                txtNode = document.createTextNode(value.toString());
            }
            if (key === "id") {
                id = value;
            }

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