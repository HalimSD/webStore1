function processForm(e) {
    let btn = document.getElementById("submitBtn");
    btn.setAttribute("disabled", "");
    btn.innerText = "Uploaden...";
    return false;
}

function attachEventHandler() {
    let form = document.getElementById("submitForm");
    form.addEventListener("submit", processForm);
}

$(attachEventHandler);