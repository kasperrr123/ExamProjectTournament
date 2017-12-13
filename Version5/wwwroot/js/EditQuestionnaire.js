var hostname = document.location.host;
var reportQuestionids = [];
var interviewQuestionids = [];

$(document).ready(function () {
    getQuestions();
    $("#dropdown").change(function () {
        getQuestions();
    });

    $("#UpdateReportQuestionButton").click(function () {
        var x = document.getElementById("tableReport").rows.length - 1;

        for (var i = 0; i < x; i++) {
            var changes = document.getElementById("tableReport").rows[i + 1].cells[2].children[0].value;
            var modifier = document.getElementById("tableReport").rows[i + 1].cells[1].innerHTML;
            var Questionaireid = getQuestionaireID("report");
            if (changes != "") {
                var currentquestionid = parseInt(reportQuestionids[i]);
                var dataToSend = {
                    fldQuestionsId: currentquestionid,
                    fldQuestion: changes,
                    fldModifier: modifier,
                    fldQuestionnaireId: Questionaireid
                }
                $.ajax({
                    url: 'http://' + hostname + '/api/questions/' + currentquestionid,
                    method: 'PUT',
                    contentType: "application/json",
                    dataType: 'json',
                    async: false,
                    data: JSON.stringify(dataToSend),
                    success: function () {
                        alert("successfully Updated Question");

                    },
                    error: function () {
                        alert("couldn't update table");
                    }
                })
            }

        }
    })
    $("#UpdateInterviewQuestions").click(function () {
        var x = document.getElementById("tableInterview").rows.length - 1;

        for (var i = 0; i < x; i++) {
            var changes = document.getElementById("tableInterview").rows[i + 1].cells[2].children[0].value;
            var modifier = document.getElementById("tableInterview").rows[i + 1].cells[1].innerHTML;
            var Questionaireid = getQuestionaireID("interview");
            if (changes != "") {
                var currentquestionid = parseInt(interviewQuestionids[i]);
                var dataToSend = {
                    fldQuestionsId: currentquestionid,
                    fldQuestion: changes,
                    fldModifier: modifier,
                    fldQuestionnaireId: Questionaireid
                }
                $.ajax({
                    url: 'http://' + hostname + '/api/questions/' + currentquestionid,
                    method: 'PUT',
                    contentType: "application/json",
                    dataType: 'json',
                    async: false,
                    data: JSON.stringify(dataToSend),
                    success: function () {
                        alert("successfully Updated Question");

                    },
                    error: function () {
                        alert("couldn't update table");
                    }
                })
            }

        }
    })

    function getQuestionaireID(type) {
        var topic = $("#dropdown").val();
        if (type == "report") {
            switch (topic) {
                case 'Business & Service':
                    return id = 1;

                case 'Science & Technology':
                    return id = 2;

                case 'Trade & Skills':
                    return id = 3;

                case 'Society & Globalization':
                    return id = 4;

                default:
            }
        } else if (type == "interview") {
            switch (topic) {
                case 'Business & Service':
                    return id = 5;

                case 'Science & Technology':
                    return id = 6;

                case 'Trade & Skills':
                    return id = 7;

                case 'Society & Globalization':
                    return id = 8;

                default:
            }
        }

    }

    function getQuestions() {
        var topic = $("#dropdown").val();
        var id, interviewID;
        switch (topic) {
            case 'Business & Service':
                id = 1;
                interviewID = 5;
                break;
            case 'Science & Technology':
                id = 2;
                interviewID = 6;
                break;
            case 'Trade & Skills':
                id = 3;
                interviewID = 7;
                break;
            case 'Society & Globalization':
                id = 4;
                interviewID = 8;
                break;
            default:
        }
        $.ajax({
            url: 'http://' + hostname + '/api/Questions/' + id,
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                UpdateTable(data, "tableReport");
                var LocalQuestions = [];
                for (var i = 0; i < data.length; i++) {
                    LocalQuestions[i] = [data[i].fldQuestionsId];
                }
                reportQuestionids = LocalQuestions;
            },
            error: function () {
                alert("couldn't update table");
            }

        });

        $.ajax({
            url: 'http://' + hostname + '/api/Questions/' + interviewID,
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                UpdateTable(data, "tableInterview");
                var LocalQuestions = [];
                for (var i = 0; i < data.length; i++) {
                    LocalQuestions[i] = [data[i].fldQuestionsId];
                }
                interviewQuestionids = LocalQuestions;
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
        for (var i = 0; i < data.length; i++) {

            // Create an empty <tr> element and add it to the 1st position of the table:
            var row = table.insertRow(i + 1);

            // Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
            var cell1 = row.insertCell(0);
            cell1.innerHTML = data[i].fldQuestion;
            var cell2 = row.insertCell(1);
            cell2.innerHTML = data[i].fldModifier;

            var cell3 = row.insertCell(2);
            cell3.innerHTML = '<textarea class="form-control" rows="4" cols="10" placeholder="Leave empty if there are no changes"/>';

            var cell4 = row.insertCell(3)
            //TODO
            cell4.innerHTML = '<button type="button" class="btn btn-danger" onclick="deleteQuestion(this)">Delete Question</button>';

        }

    }
});
function deleteQuestion(button) {
    alert(button.parentNode.parentNode.parentNode.parentNode.id)
    var indexToDelete = button.parentNode.parentNode.rowIndex - 1
    if (button.parentNode.parentNode.parentNode.parentNode.id == "tableReport") {
        var reportIndex = reportQuestionids[indexToDelete];
        $.ajax({
            url: 'http://' + hostname + '/api/Questions/' + reportIndex,
            type: "DELETE",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                location.reload(true);
            },
            error: function () {
                alert("couldn't Delete Question");
            }
        });
    } else {
        alert("inInterview");
        var interviewIndex = interviewQuestionids[indexToDelete];
        $.ajax({
            url: 'http://' + hostname + '/api/Questions/' + interviewIndex,
            type: "DELETE",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                location.reload(true);
            },
            error: function () {
                alert("couldn't Delete Question");
            }
        });
    }
    
}





