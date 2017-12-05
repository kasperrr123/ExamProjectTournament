$(document).ready(function () {
    var hostname = document.location.host;
    alert("Inside AdminScript");

    var collectionOfTeams = getTeams();


    $('#table').bootstraptable({
        data: getTeams()
    });


    function getTeams() {
        var collectionOfTeams;
        $.ajax({
            url: 'http://' + hostname + '/api/teams',
            type: "GET",
            contentType: "application/json",
            dataType: "json",
        }).then(function (data) {
            for (var i = 0; i < data.length; i++) {
                collectionOfTeams[i] = data[i].fldProjectName;
                alert(data[i].fldProjectName)
            }
            for (var team in collectionOfTeams) {
                alert(team.fldProjectName);
            }

        });
        return collectionOfTeams;
    }

});



