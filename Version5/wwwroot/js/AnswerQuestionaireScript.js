var hostname = document.location.host;

$(document).ready(function () {
    var teamname = gup('Teamname');
    var type = gup('type')
    teamname = decodeURI(teamname)
    console.log(teamname + " " + type);
    getQuestions(teamname, type);

    function gup(name, url) {
        if (!url) url = location.href;
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regexS = "[\\?&]" + name + "=([^&#]*)";
        var regex = new RegExp(regexS);
        var results = regex.exec(url);
        return results == null ? null : results[1];
    }

    function getQuestions(teamname, type) {
        $.ajax({
            url: 'http://' + hostname + '/api/GetQuestionsForJudge/'+teamname+'/'+type,
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
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
        for (var i = 0; i < data.length; i++) {

            // Create an empty <tr> element and add it to the 1st position of the table:
            var row = table.insertRow(i + 1);

            // Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
            var cell1 = row.insertCell(0);
            cell1.innerHTML = data[i].fldQuestion;
            var cell2 = row.insertCell(1);
            cell2.innerHTML = data[i].fldModifier;

            var cell3 = row.insertCell(2);
            cell3.innerHTML = '<textarea rows="4" cols="50"/>';

        }

    }
});






