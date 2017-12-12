
$(document).ready(function () {
    var hostname = document.location.host;


    $.ajax({
        url: 'http://' + hostname + '/api/GetProjectURL',
        method: 'GET',
        contentType: 'application/json',
        success: function (data) {

            var projectdata = data;
            for (var i = 0; i < data.length; i++) {
                $.ajax({
                    url: 'http://' + hostname + '/api/GetScoreDependingOnTeamName/' + data[i].fldTeamName,
                    method: 'GET',
                    contentType: 'application/json',
                    async: false,
                    success: function (data) {
                        var interviewscore = data.interviewScore;
                        var reportscore = data.reportScore;
                        var totalscore = data.totalscore;



                        updatetable(projectdata, "myManagment", data.interviewScore, data.reportScore, data.totalscore);

                    },
                    error: function () {
                        alert("error loading teamscores");
                    }
                })

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

});

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

var increment = (function (n) {
    return function () {
        n += 1;
        return n;
    }
}(-1))

function updatetable(data, tablename, InterviewScore, ReportScore, TotalScore) {
    var index = increment();

    var table = document.getElementById(tablename);

    // Create an empty <tr> element and add it to the 1st position of the table:
    var row = table.insertRow();

    // Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
    var cell1 = row.insertCell(0);
    cell1.innerHTML = data[index].fldTeamName;

    var cell2 = row.insertCell(1);

    var a = document.createElement('a');
    var linkText = document.createTextNode("View report");
    a.appendChild(linkText);
    a.title = "View report";
    a.target = "_blank";
    a.href = data[index].fldProjectFilePath;
    cell2.appendChild(a);

    var cell3 = row.insertCell(2);
    if (ReportScore > 0) {
        cell3.innerHTML = ReportScore;
    } else {
        var ReportInterview = document.createElement('tr');
        ReportInterview.innerHTML = '<button id="' + data[index].fldTeamName + '" class="btn btn-danger" onclick="OpenReportPage(this)">JudgeReport</button>';

        cell3.append(ReportInterview);
    }
    var cell4 = row.insertCell(3);
    if (InterviewScore > 0) {
        cell4.innerHTML = InterviewScore;
    } else {
      
        var InterviewButton = document.createElement('tr');
        InterviewButton.innerHTML = '<button id="' + data[index].fldTeamName + '" class="btn btn-danger" onclick="OpenInterviewPage(this)">Judge Interview</button>';

        cell4.append(InterviewButton);
    }


    var cell5 = row.insertCell(4);

    cell5.innerHTML = TotalScore;

    index = index + 1;

}

function OpenReportPage(teamname) {
    var hostname = document.location.host;

    var size;
    if (screen.height <= 768 && screen.width <= 1366) {
        size = "height=" + (screen.height - 125) + "," + "width=" + (screen.width - 100);

    } else {
        size = "height=" + (screen.height - 250) + "," + "width=" + (screen.width - 850);

    }

    mywindow = window.open('http://' + hostname + '/AnswerQuestionairePage.html?Teamname=' + teamname.id + '&type=report', "_blank", size);
}
function OpenInterviewPage(teamname) {
    var hostname = document.location.host;

    var size;
    if (screen.height <= 768 && screen.width <= 1366) {
        size = "height=" + (screen.height - 125) + "," + "width=" + (screen.width - 100);

    } else {
        size = "height=" + (screen.height - 250) + "," + "width=" + (screen.width - 850);

    }
    mywindow = window.open('http://' + hostname + '/AnswerQuestionairePage.html?Teamname=' + teamname.id + '&type=interview', "_blank", size);
}
