function init() {
    // Do GET request to GetData action and pass JSON result to populateTable()
    $.get("/admin/categorylist/getdata", function (jsonModel) {
        populateTable(jsonModel, false);
    });
    
    // Setup event handlers
    let filters = ["#filterId", "#filterName", "#filterProductCount", "#filterAttributeCount"];
    for (let i in filters) {
        $(filters[i]).on("input", onInputChanged);
    }
}

function onInputChanged(pageNumber=1) {
    let noFilters = false;
    let Id = document.getElementById("filterId").value.toString();
    let Name = document.getElementById("filterName").value.toString();
    let ProductCount = document.getElementById("filterProductCount").value.toString();
    let AttributeCount = document.getElementById("filterAttributeCount").value.toString();
    
    if (Id === "" && Name === "" && ProductCount === "" && AttributeCount === "") {
        noFilters = true;
    }
    
    if (noFilters == false) {
        $.get(
            "/admin/categorylist/getdatafiltered",
            {
                id : Id,
                name : Name,
                productCount: ProductCount,
                attributeCount: AttributeCount,
                pageIndex : pageNumber.toString()
            },
            function (data) {
                populateTable(data, true);
            }
        );
    } else {
        $.get("/admin/categorylist/getdata", {pageIndex : pageNumber.toString()}, function (data) {
            populateTable(data, false);
        });
    }
}

// Creates the options column of a row
function createOptionsColumn(productId) {
    let tdElement = document.createElement("td");
    
    // Delete option
    let aElementDelete = document.createElement("a");
    let aElementDeleteTxt = document.createTextNode("Verwijderen");
    aElementDelete.appendChild(aElementDeleteTxt);
    aElementDelete.setAttribute("href", "/Admin/CategoryList/ConfirmDelete?id=" + productId.toString());
    
    // Append everything
    tdElement.appendChild(aElementDelete);
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
            let txtNode = document.createTextNode(value.toString());
            if (key === "id") {
                tdElement.setAttribute("width", "10%");
                id = value;
            }
            
            // Append the newly created elements into their respective parent elements
            tdElement.appendChild(txtNode);
            trElement.appendChild(tdElement);
        });
        
        
        trElement.appendChild(createOptionsColumn(id));
        tableBody.appendChild(trElement);
        createPagination(jsonModel)
    }
    
}

function createPagination(jsonModel) {
    let pageNumber = jsonModel.pageNumber;
    let totalPages = jsonModel.totalPages;
    let root = document.getElementById("pagination")

    // Clear the root element
    while (root.firstChild) {
        root.removeChild(root.firstChild);
    }
    
    {
        // Create the previous page button
        let liElement = document.createElement("li");
        let aElement = document.createElement("a");
        if (pageNumber === 1) {
            liElement.className = "page-item disabled";
            aElement.setAttribute("tabindex", "-1");
        } else {
            liElement.className = "page-item";
            aElement.addEventListener("click",function() {
                onInputChanged(pageNumber-1)
            });
        }
        aElement.className = "page-link";
        aElement.appendChild(document.createTextNode("Vorige"));
        liElement.appendChild(aElement);
        root.appendChild(liElement);
    }
    
    // Create page button foreach page
    for (let i=1; i <= totalPages; i++) {
        let liElement = document.createElement("li");
        if (i === pageNumber) {
            liElement.className = "page-item active";
        } else {
            liElement.className = "page-item";
        }
        // Create the <a> element
        let aElement = document.createElement("a");
        aElement.addEventListener("click",function() {
            onInputChanged(i.toString());
        });
        aElement.className = "page-link";
        aElement.appendChild(document.createTextNode(i.toString()));
        liElement.appendChild(aElement);
        root.appendChild(liElement);
    }
    
    {
        // Create the next page button
        let liElement = document.createElement("li");
        let aElement = document.createElement("a");
        if (pageNumber === totalPages) {
            liElement.className = "page-item disabled";
            aElement.setAttribute("tabindex", "-1");
        } else {
            liElement.className = "page-item";
            aElement.addEventListener("click",function() {
                onInputChanged(pageNumber+1);
            });
        }
        aElement.className = "page-link";
        aElement.appendChild(document.createTextNode("Volgende"));
        liElement.appendChild(aElement);
        root.appendChild(liElement);
    }
}



window.onload = init;