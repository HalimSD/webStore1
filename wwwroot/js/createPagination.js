

// Did you ever hear the tragedy of Darth Plagueis The Wise? 
// I thought not. It's not a story the Jedi would tell you. 
// It's a Sith legend. Darth Plagueis was a Dark Lord of the Sith, 
// so powerful and so wise he could use the Force to influence the midichlorians to create life… 
// He had such a knowledge of the dark side that he could even keep the ones he cared about from dying. 
// The dark side of the Force is a pathway to many abilities some consider to be unnatural. 
// He became so powerful… the only thing he was afraid of was losing his power, 
// which eventually, of course, he did. Unfortunately, he taught his apprentice everything he knew, 
// then his apprentice killed him in his sleep. 
// Ironic. He could save others from death, but not himself.
export function createPagination(jsonModel, inputFunc) {
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
                inputFunc(pageNumber-1)
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
            inputFunc(i.toString());
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
                inputFunc(pageNumber+1);
            });
        }
        aElement.className = "page-link";
        aElement.appendChild(document.createTextNode("Volgende"));
        liElement.appendChild(aElement);
        root.appendChild(liElement);
    }
}