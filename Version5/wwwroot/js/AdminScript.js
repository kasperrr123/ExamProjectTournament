$(document).ready(function () {
    var hostname = document.location.host;

    var collectionOfTeams = getTeams();

    function getTeams() {
        var collectionOfTeams = [];
        $.ajax({
            url: 'http://' + hostname + '/api/teams',
            type: "GET",
            contentType: "application/json",
            dataType: "json",
        }).then(function (fromServer) {
            $('#table').bootstrapTable({
                data: fromServer
            });
        });

    };

    var myWindow;
    $("#openEditQuestionnaire").click(function () {
        var size;
        if (screen.height <= 768 && screen.width <= 1366) {
            size = "height=" + (screen.height - 125) + "," + "width=" + (screen.width - 100);

        } else {
            size = "height=" + (screen.height - 250) + "," + "width=" + (screen.width - 850);

        }

        myWindow = window.open('http://' + hostname + '/EditQuestionnairePage.html', "_blank", size);
    });

});










