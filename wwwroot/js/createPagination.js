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
export function createPagination(jsonModel, inputHandler) {
    let pageNumber = jsonModel.pageNumber;
    let totalPages = jsonModel.totalPages;
    let root = document.getElementById("pagination");

    // Clear the root element
    while (root.firstChild) {
        root.removeChild(root.firstChild);
    }
    
    // Remove all items in the pop over form dropdown
    let popoverDropdown = document.getElementById("popover-content");
    while (popoverDropdown.firstChild) {
        popoverDropdown.removeChild(popoverDropdown.firstChild);
    }

    // Create the 'jump to first page' button
    if (pageNumber > 1) {
        createSkipToPageBtn(inputHandler, root, "«", 1);
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
            aElement.addEventListener("click", function () {
                inputHandler(pageNumber - 1)
            });
        }
        aElement.className = "page-link";
        aElement.appendChild(document.createTextNode("Vorige"));
        aElement.href = "#";
        liElement.appendChild(aElement);
        root.appendChild(liElement);
    }

    // Create the last 3 page buttons
    for (let i = pageNumber - 3; i <= pageNumber - 1; i++) {
        if (i < 1) continue;
        createPageBtn(inputHandler, root, false, i);
    }

    // Create the active page button
    createPageBtn(inputHandler, root, true, pageNumber);

    // Create the next 3 page buttons
    for (let i = pageNumber + 1; i <= pageNumber + 3; i++) {
        if (i > totalPages) continue;
        createPageBtn(inputHandler, root, false, i);
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
            aElement.addEventListener("click", function () {
                inputHandler(pageNumber + 1);
            });
        }
        aElement.className = "page-link";
        aElement.appendChild(document.createTextNode("Volgende"));
        aElement.href = "#";
        liElement.appendChild(aElement);
        root.appendChild(liElement);
    }

    // Create the 'jump to last page' button
    if (pageNumber < totalPages) {
        createSkipToPageBtn(inputHandler, root, "»", totalPages);
    }

    createPopover(pageNumber, totalPages, root, inputHandler);
}

/**
 * Creates a pagination page button
 * @param inputHandler - (function) Function that handles input
 * @param root - (HTML element) The root element where the created element will be appended to
 * @param active - (bool) Indicate if the button is the currently selected button
 * @param pageNumber - (int) The page number that this button will represent
 */
function createPageBtn(inputHandler, root, active, pageNumber) {
    let liElement = document.createElement("li");
    if (active) {
        liElement.className = "page-item active";
    } else {
        liElement.className = "page-item";
    }

    // Create the <a> element
    let aElement = document.createElement("a");
    aElement.addEventListener("click", function () {
        inputHandler(pageNumber.toString());
    });
    aElement.className = "page-link";
    aElement.appendChild(document.createTextNode(pageNumber.toString()));
    aElement.href = "#";
    liElement.appendChild(aElement);
    root.appendChild(liElement);
}

function createSkipToPageBtn(inputHandler, root, txt, skipToPageNumber) {
    let liElement = document.createElement("li");
    let aElement = document.createElement("a");

    liElement.className = "page-item";
    aElement.addEventListener("click", function () {
        inputHandler(skipToPageNumber)
    });
    aElement.className = "page-link";
    aElement.appendChild(document.createTextNode(txt));
    liElement.appendChild(aElement);
    root.appendChild(liElement);
}

function createPopoverForm() {
    
    // Create the content
    let br = document.createElement("br");
    let root = document.getElementById("popover-content");
    let form = document.createElement("form");
    let select = document.createElement("select");
    let button = document.createElement("button");
    form.id = "popover-form";
    select.id = "pageJumpFormSelect";
    select.className = "form-control";
    button.type = "submit";
    button.className = "btn btn-primary btn-block";
    button.innerHTML = "Ga";
    
    form.appendChild(select);
    form.appendChild(br);
    form.appendChild(button);
    root.appendChild(form);
}



// Doesn't work
function createPopover(pageNumber, totalPages, root, inputHandler) {

    createPopoverForm();
    
    // Create the <a> element that creates the popover on click
    let aElement = document.createElement("a");
    aElement.id = "listPageJumper";
    aElement.className = "paginationJumpTo";
    aElement.setAttribute("role", "button");
    aElement.setAttribute("title", "Spring naar pagina:");
    aElement.setAttribute("data-toggle", "popover");
    aElement.setAttribute("data-placement", "top");
    root.appendChild(aElement);


    aElement.append(document.createTextNode(`Pagina ${pageNumber} van ${totalPages}`));
    // Create a fancy dropdown icon that will appear next to the text
    let iconElement = document.createElement("i");
    iconElement.className = "inline-icon material-icons";
    iconElement.append(document.createTextNode("arrow_drop_down"));
    aElement.appendChild(iconElement);
    let selectElement = document.getElementById("pageJumpFormSelect");
    
    // Populate the form select input
    for (let i = 1; i <= totalPages; i++) {
        let option = document.createElement("option");
        option.value = i.toString();
        option.innerHTML = i.toString();
        selectElement.appendChild(option);
    }
    
    $(document).on('submit', '.popover-body',function(event){
        console.log("Event triggered!");
        event.preventDefault();
        let selectElement = document.getElementsByClassName("popover-body")[0].querySelector("form").querySelector("select");
        let value = selectElement.options[selectElement.selectedIndex].value;
        inputHandler(value);
        $('#listPageJumper').popover('hide');
        event.stopImmediatePropagation();
    });
    
    
    $('#listPageJumper').popover({
        html: true,
        content: function () {
            return $("#popover-content").html();
        }
    });
    
}