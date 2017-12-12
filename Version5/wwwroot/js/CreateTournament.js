var hostname = document.location.host;

$(document).ready(function () {

    $("#createTournamentBtn").click(function () {

        postTournament()

    });

});


function postTournament() {
    var dataObj = {
        fldTournamentName: $("#name").val(),
        fldStartDate: $("#startDate").val(),
        fldEndDate: $("#endDate").val(),
        fldAddress: $("#address").val()
    }
    if (dataObj.fldAddress != "" && dataObj.fldStartDate != "" && dataObj.fldEndDate != "" && dataObj.fldTournamentName != "") {
        $.ajax({
            url: 'http://' + hostname + '/api/tournaments',
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(dataObj),
            success: function () {
                $("#ModalForShowingSuccessMsg").modal();
                $('#ModalForShowingSuccessMsg').on('hidden.bs.modal', function () {
                    document.location.pathname = "adminPage.html";
                })
            }
        });
    } else {
        alert("You have to fill out every field");
    }
};





