function init() {
    // Do GET request to GetData action and pass JSON result to populateTable()
    $.get("/home/getcategories", function (jsonModel) {
        populateDropDown(jsonModel, false);
    });
}

function populateDropDown(data) {
    // Element that will contain all the dropdown items
    let dropdown = document.getElementById("productsDropdown");
    
    // Add option to view all products
    let aElement = document.createElement("a");
    let txtElement = document.createTextNode("Alle Producten");
    aElement.appendChild(txtElement);
    aElement.className = "dropdown-item";
    aElement.setAttribute("href", "/Category");
    dropdown.append(aElement);
    
    // Add divider
    let divider = document.createElement("div");
    divider.className = "dropdown-divider";
    dropdown.appendChild(divider);
    
    // Loop through the data and add all elements
    for (let i in data) {
        // Array from the current iteration
        // Index 0: Category name
        // Index 1: Category ID
        let currArray = data[i];
        
        // Create the <a> element
        let aElement = document.createElement("a");
        let txtElement = document.createTextNode(currArray[0]);
        aElement.appendChild(txtElement);
        aElement.className = "dropdown-item";
        aElement.setAttribute("href", "/Category?categoryId=" + currArray[1]);
        
        // Add it to the dropdown
        dropdown.appendChild(aElement);
    }
    
}

// Run init() once HTML is loaded
$(init);