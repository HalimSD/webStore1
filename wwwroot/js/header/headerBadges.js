function init() {
    $.get("/home/getfavoritecount", function (data) {
        addBadge(data, "favoritesLink");
    });

    $.get("/home/getcartcount", function (data) {
        addBadge(data, "cartLink");
    });
}

function addBadge(count, elementId) {
    if (count === -1) return;

    let parent = document.getElementById(elementId);
    let span = document.createElement("span");
    span.className = "badge badge-primary";
    span.innerHTML = count.toString();
    parent.innerHTML += "  ";
    parent.append(span);
}


$(init);