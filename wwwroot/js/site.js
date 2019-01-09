// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function enablePopOver() {
    $('#categoryPageJumper').popover({
        html : true,
        content: function() {
            return $("#popover-content").html();
        }
    });
}

$(enablePopOver);