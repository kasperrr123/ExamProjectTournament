$(document).ready(function () {
    var hostname = document.location.host;


    $.ajax({
        url: 'http://' + hostname + '/api/GetProjectURL',
        method: 'GET',
        contentType: 'application/json',
        success: function (data) {
           
            for (var i = 0; i < data.length; i++) {
                alert(data.FldProjectFilePath);
                var table = document.getElementById("myManagment");

                // Create an empty <tr> element and add it to the 1st position of the table:
                var row = table.insertRow(i + 1);

                // Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
                var cell1 = row.insertCell(0);
                cell1.innerHTML = data[i].fldTeamName;

                var cell2 = row.insertCell(1);
                var a = document.createElement('a');
                var linkText = document.createTextNode("View report");
                a.appendChild(linkText);
                a.title = "View report";
                a.href = data[i].FldProjectFilePath;
                cell2.appendChild(a);

                //TODO
                //var cell3 = row.insertCell(2);
                

                //var cellbutton = document.createElement("input");
                //cellbutton.type = "btn";
                //cellbutton.className = "btn";
                //cell3.append(cellbutton);

                // Add some text to the new cells:
             
                

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
                var url;
                alert("got a project: " + data);
                url = "http://" + hostname + data;
                return url;
            },
            error: function () {
                alert("problem getting project link");
            }
        });
   
        
        
    }
}

);