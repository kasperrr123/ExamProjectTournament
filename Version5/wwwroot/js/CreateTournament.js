$(document).ready(function () {
    var hostname = document.location.host;

    $("#createTournamentBtn").click(function() {
        postTournament();
    });


    function postTournament() {
        var dataObj = {
            fldTournamentName: $("#name").val(),
            fldStartDate: $("#startDate").val(),
            fldEndDate: $("#endDate").val(),
            fldAddress: $("#address").val()
        }
        $.ajax({
            url: 'http://' + hostname + '/api/tournaments',
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(dataObj),
            success: function () {
                alert("Success");
            }
        }).then(function (fromServer) {
            alert(fromServer);
        });
    };
  

});


