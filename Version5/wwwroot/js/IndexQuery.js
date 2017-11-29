var sessionToken;

$(document).ready(function getInformation() {
    $.ajax({
        url: "http://localhost:55655/api/Tournaments", success: function (result) {
            var address = result[result.length - 1].fldAddress;
            $("#placeinformation").html(address)
        }
    });
    $.ajax({
        url: "http://localhost:55655/api/Tournaments", success: function (result) {
            var endTime = result[result.length - 1].fldEndDate;
            $("#endtimeinformation").html(formatDateTime(endTime))
        }
    });
    $.ajax({
        url: "http://localhost:55655/api/Tournaments", success: function (result) {
            var startTime = result[result.length - 1].fldStartDate;
            $("#starttimeinformation").html(formatDateTime(startTime));
        }
    });


});

$(document).ready(function login() {
    $("#loginbutton").click(function () {

        $.ajax({
            url: "http://localhost:55655/api/logins",
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function () {
                alert("Got Tournament ID");
            }
        }).then(function (data) {
            alert("TournamentID = " + data[data.length - 1].fldTournamentId);
            var tournamentID = data[data.length - 1].fldTournamentId;
            alert(tournamentID);
        })


    });
});




function formatDateTime(datetime) {
    var datetimeWithOutT = datetime.replace("T", " ");
    var parts = datetimeWithOutT.split(/[- :]/);
    var wanted = parts[2] + '/' + parts[1] + '/' + parts[0] + ' ' + parts[3] + ':' + parts[4];
    return wanted;
}