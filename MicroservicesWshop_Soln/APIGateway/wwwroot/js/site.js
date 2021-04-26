// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#compute").click(function (e) {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "/Home/Compute",
            data: JSON.stringify({
                Value: $("#expression").val()
            }),
            success: function (response) {
                response = JSON.parse(response);
                alert("Expression yields: " + response.result);
            }
        });
    });

    /*
    $.ajax({
        type: "PUT",
        contentType: "application/json",
        url: "/Home/PutTest",
        data: JSON.stringify({ Value: "1+1" }),
        success: function (response) {
            response = JSON.parse(response);
            alert(response.result);
        }
    });
    */
});