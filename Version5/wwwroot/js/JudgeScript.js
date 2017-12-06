﻿$(document).ready(function () {
    var hostname = document.location.host;


    $.ajax({
        url: 'http://' + hostname + '/api/GetFldTeamNameController',
        method: 'GET',
        contentType: 'application/json',
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                var table = document.getElementById("myManagment");

                // Create an empty <tr> element and add it to the 1st position of the table:
                var row = table.insertRow(i + 1);

                // Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
                var cell1 = row.insertCell(0);
                var cell2 = row.insertCell(1);
                var cellbutton = document.createElement("input");
                cellbutton.type = "btn";
                cellbutton.className = "btn";
                cellbutton.onclick = (function (entry) {
                    return function () {
                        //TODO
                    };
                })(entry);
                cell2.append(cellbutton);

                // Add some text to the new cells:
                cell1.innerHTML = "NEW CELL1";
                cell2.innerHTML = "NEW CELL2";

            }

        },
        error: function () {
            alert("Error loading teams");
        }
    });
    //GetLinkFromTeamName("Davids team");
    // Find a <table> element with id="myTable":
    
    function GetLinkFromTeamName(teamname) {
        $.ajax({
            url: 'http://' + hostname + '/api/getprojecturl/' + teamname,
            method: 'GET',
            contentType: 'application/json',
            success: function (data) {
                document.location.pathname = data;
            },
            error: function () {
                alert("problem getting project link");
            }
        });
    }
}

);