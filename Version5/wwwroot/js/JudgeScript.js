


function OpenReportPage(teamname) {
    var hostname = document.location.host;

    var size;
    if (screen.height <= 768 && screen.width <= 1366) {
        size = "height=" + (screen.height - 125) + "," + "width=" + (screen.width - 100);

    } else {
        size = "height=" + (screen.height - 250) + "," + "width=" + (screen.width - 850);

    }

    mywindow = window.open('http://'+hostname+'/AnswerQuestionairePage.html?Teamname=' + teamname.id + '&type=report', "_blank", size);
}
function OpenInterviewPage(teamname) {
    var hostname = document.location.host;

    var size;
    if (screen.height <= 768 && screen.width <= 1366) {
        size = "height=" + (screen.height - 125) + "," + "width=" + (screen.width - 100);

    } else {
        size = "height=" + (screen.height - 250) + "," + "width=" + (screen.width - 850);

    }
    mywindow = window.open('http://'+hostname+'/AnswerQuestionairePage.html?Teamname=' + teamname.id + '&type=interview', "_blank", size);
}
$(document).ready(function () {
    checkLogin();
   
    var hostname = document.location.host;

    $.ajax({
        url: 'http://' + hostname + '/api/GetProjectURL',
        method: 'GET',
        contentType: 'application/json',
        success: function (data) {

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

                var ReportInterview = document.createElement('tr');
                ReportInterview.innerHTML = '<button id="' + data[i].fldTeamName + '" class="btn btn-danger" onclick="OpenReportPage(this)">JudgeReport</button>';

                cell3.append(ReportInterview);

                var cell4 = row.insertCell(3);
                var InterviewButton = document.createElement('tr');
                InterviewButton.innerHTML = '<button id="' + data[i].fldTeamName + '" class="btn btn-danger" onclick="OpenInterviewPage(this)">Judge Interview</button>';

                cell4.append(InterviewButton);


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
    function checkLogin() {
        if (document.cookie.length > 0) {
            var cookie = document.cookie;
            var rank = cookie.split("=")[1];
            if (rank == "355" || rank == "395") {

            } else {
                $('#bodyid').get(0).hidden = true;
                alert("Not allowed");
            }
        } else {
            $('#bodyid').get(0).hidden = true;
            alert("You have to be logged in");
        }

    }

}

);