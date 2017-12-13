var hostname = document.location.host;

$(document).ready(function () {
    getQuestions();
    $("#dropdown").change(function () {
        getQuestions();
    });

    $




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
            cell4.innerHTML = '<button type="button" class="btn btn-danger" onclick="todofunction">Delete Question</button>';

        }

    }
});






