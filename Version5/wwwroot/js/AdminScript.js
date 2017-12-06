$(document).ready(function () {
    var hostname = document.location.host;
    //alert("Inside AdminScript");

    var collectionOfTeams = getTeams();





    function getTeams() {
        var collectionOfTeams = [];
        $.ajax({
            url: 'http://' + hostname + '/api/teams',
            type: "GET",
            contentType: "application/json",
            dataType: "json",
        }).then(function (fromServer) {
            alert(fromServer);
           
            $('#table').bootstrapTable({
                data: fromServer
            });
        });




    };


});







