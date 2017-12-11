$(document).ready(function () {
    // Just a variable holding the host string.
    var hostname = document.location.host;
    // Getting teams for generating the schedule.
    getTeamsForSchedule();


    function getTeamsForSchedule() {
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


});

