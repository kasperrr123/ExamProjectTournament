$(document).ready(function () {
    var hostname = document.location.host;
    // Getting teams for generating the schedule.
    getTeamsForSchedule();
    // First time getting logins under management.
    getSpecificLogin();
    // For every time the dropdown changes.
    $("#dropdownCategory").change(function () {
        getSpecificLogin();
    });


    // Here the functions are.
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
    function getSpecificLogin() {
        if ($("#dropdownCategory option:selected").index() == 0) {
            $.ajax({
                url: 'http://' + hostname + '/api/logins/management/301',
                type: "GET",
                contentType: "application/json",
                dataType: "json",
            }).then(function (fromServer) {
                $('#manageLoginsTable').bootstrapTable("load", fromServer);
                $('#manageLoginsTable').bootstrapTable({
                    data: fromServer
                });
            });
        } else {
            $.ajax({
                url: 'http://' + hostname + '/api/logins/management/355',
                type: "GET",
                contentType: "application/json",
                dataType: "json",
            }).then(function (fromServer) {
                $('#manageLoginsTable').bootstrapTable("load", fromServer);

            });
        }
        

    };


    // This handles the opening of the new window when Quesitonnaire option is clicked.
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










