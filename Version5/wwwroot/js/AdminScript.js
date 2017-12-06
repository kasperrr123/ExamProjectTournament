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
    $("#openQuestionaires").click(function () {
        myWindow = window.open('http://youtube.com', '_blank', 'height=300, width=300');
    });


});







