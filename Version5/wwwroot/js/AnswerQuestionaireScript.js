var hostname = document.location.host;
var questionids = [];
var teamname = gup('Teamname');
var type = gup('type');
var Questionaireid;
function gup(name, url) {
    if (!url) url = location.href;
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(url);
    return results == null ? null : results[1];
}
$(document).ready(function () {

    teamname = decodeURI(teamname);
    getQuestions(teamname, type);

    function getQuestions(teamname, type) {
        $.ajax({
            url: 'http://' + hostname + '/api/GetQuestionsForJudge/' + teamname + '/' + type,
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                Questionaireid = data[0].fldQuestionnaireId;

                UpdateTable(data, "table");
            },
            error: function () {
                alert("couldn't update table");
            }

        });

    }


    function UpdateTable(data, tablename) {
        var table = document.getElementById(tablename);
        var tableHeaderRowCount = 1;
        var rowCount = table.rows.length;
        for (var r = tableHeaderRowCount; r < rowCount; r++) {
            table.deleteRow(tableHeaderRowCount);
        }
        var LocalQuestions = [];
        for (var i = 0; i < data.length; i++) {
            LocalQuestions[i] = [data[i].fldQuestionsId];
        }
        questionids = LocalQuestions;
        for (var i = 0; i < data.length; i++) {

            // Create an empty <tr> element and add it to the 1st position of the table:
            var row = table.insertRow(i + 1);

            // Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
            var cell1 = row.insertCell(0);
            cell1.innerHTML = data[i].fldQuestion;
            var cell2 = row.insertCell(1);
            cell2.innerHTML = data[i].fldModifier;

            var cell3 = row.insertCell(2);
            cell3.innerHTML = '<input type="text" onkeypress="return event.charCode >= 48 && event.charCode <= 57"></input>';

        }

    }
    $("#giveAnswer").click(function () {
        getJudgeLetter();


    });
    function getJudgeLetter() {
        var x = document.getElementById("table").rows.length;

        var email = document.cookie.split("=")[0];
        var judgeletter;
     
        alert('http://' + hostname + '/api/GetQuestionsForJudge/' + email);
        $.ajax({
            url: 'http://' + hostname + '/api/GetQuestionsForJudge/' + email,
            method: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                judgeletter = data.fldJudgeLetter;
                
                for (var i = 0; i < x; i++) {
                    var score = document.getElementById("table").rows[i + 1].cells[2].children[0].value;
                    var currentquestionid = parseInt(questionids[i]);

                    var dataToSend = {
                        FldTeamName: teamname,
                        FldQuestionsId: currentquestionid,
                        FldJudgeLetter: judgeletter,
                        FldPoint: score
                    }
                    alert(JSON.stringify(data));
                    $.ajax({
                        url: 'http://' + hostname + '/api/answers',
                        method: 'POST',
                        contentType: "application/json",
                        dataType:'json',
                        data: JSON.stringify(dataToSend),
                        success: function () {
                           
                        },
                        error: function () {
                            alert("couldn't update table");
                        }
                    })
                }
            },
            error: function () {
                alert("Error Getting JudgeLetter");
            }
        })
    }

});






