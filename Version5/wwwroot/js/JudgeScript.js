$(document).ready(function () {
    var hostname = document.location.host;


    $.ajax({
        url: 'http://' + hostname + '/api/GetProjectURL',
        method: 'GET',
        contentType: 'application/json',
        success: function (data) {
            var size;
            if (screen.height <= 768 && screen.width <= 1366) {
                size = "height=" + (screen.height - 125) + "," + "width=" + (screen.width - 100);

            } else {
                size = "height=" + (screen.height - 250) + "," + "width=" + (screen.width - 850);

            }

            for (var i = 0; i < data.length; i++) {
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
                a.target = "_blank";
                data[i].fldProjectFilePath;
                a.href = data[i].fldProjectFilePath;
                cell2.appendChild(a);
                
                var cell3 = row.insertCell(2);
                

                var JudgeReportButton = document.createElement("button");
                JudgeReportButton.innerText = "JudgeReport";
                JudgeReportButton.type = "btn";
                JudgeReportButton.className = "btn btn-danger";
                JudgeReportButton.onclick = function () {
                    window.open('http://' + hostname + '/EditQuestionnairePage.html', "_blank", size);
                }
                cell3.append(JudgeReportButton);

                var cell4 = row.insertCell(3);

                var judgeInterviewButton = document.createElement("button");
                judgeInterviewButton.innerText = "JudgeInterview";
                judgeInterviewButton.type = "btn";
                judgeInterviewButton.className = "btn btn-danger";
                judgeInterviewButton.onclick = function () {
                    alert("TODO");
                }
                cell4.append(judgeInterviewButton);

                var cell5 = row.insertCell(4);

                cell5.innerHTML = "add score here";

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