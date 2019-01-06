function enablePopOver() {
    $('#paginationJumpTo').popover({
        html : true,
        content: function() {
            return $("#popover-content").html();
        }
    });
}

$(enablePopOver);