$(document).ready(function () {

    var hostname = document.location.host;
    var email = document.cookie.split("=")[0];
    $.ajax({
        url: 'http://' + hostname + '/api/GetScoreDependingOnLogin/' + email,
        method: 'GET',
        contentType: 'application/json',
        success: function (data) {

            var table = document.getElementById("myTable");

            // Create an empty <tr> element and add it to the 1st position of the table:
            var row = table.insertRow(1);

            // Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
            var cell1 = row.insertCell(0);
            cell1.innerHTML = data.reportScore;

            var cell2 = row.insertCell(1);
            cell2.innerHTML = data.interviewScore;

            var cell3 = row.insertCell(2);
            cell3.innerHTML = data.totalscore;

        },
        error: function () {
            alert("Error loading teams");
        }


    })

    // Opening report.
    $("#openReport").click(function () {
        $.ajax({
            url: 'http://' + hostname + '/api/GetProjectURL/' + email,
            method: 'GET',
            contentType: 'application/json',
            success: function (data) {
                document.location.pathname = data.fldPathName;
            },
            error: function () {
                alert("Error getting pathname");
            }

        })

    });
});

    function checkLogin() {
        if (document.cookie.length > 0) {
            var cookie = document.cookie;
            var rank = cookie.split("=")[1];
            if (rank == "301" || rank == "395") {

            } else {
                $('#bodyid').get(0).hidden = true;
                alert("Not allowed");
            }
        } else {
            $('#bodyid').get(0).hidden = true;
            alert("You have to be logged in");
        }

    }


