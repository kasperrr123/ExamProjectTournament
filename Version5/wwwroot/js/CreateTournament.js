var hostname = document.location.host;

$(document).ready(function () {

    $("#createTournamentBtn").click(function () {

        postTournament()

    });

    //$("#closeBtn").click(function () {
    //    $("ModalForShowingSuccessMsg").modal("hide");
    //    document.location.pathname = "adminPage.html";

    //});




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
            $("#ModalForShowingSuccessMsg").modal();
            $('#ModalForShowingSuccessMsg').on('hidden.bs.modal', function () {
                document.location.pathname = "adminPage.html";
            })
        }
    });
};





