export function createPagination(jsonModel) {
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