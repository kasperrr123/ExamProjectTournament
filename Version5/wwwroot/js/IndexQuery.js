$(document).ready(function getPlace() {
    $.ajax({
        url: "http://localhost:55655/api/Tournaments", success: function (result) {
            var address = result[result.length - 1].fldAddress;
            $("#placeinformation").html(address)
        }
    });
    $.ajax({
        url: "http://localhost:55655/api/Tournaments", success: function (result) {
            var endTime = result[result.length - 1].fldEndDate;


     

            $("#endtimeinformation").html(endTime)
        }
    });
    $.ajax({
        url: "http://localhost:55655/api/Tournaments", success: function (result) {
            var startTime = result[result.length - 1].fldStartDate;
            $("#starttimeinformation").html(startTime)
        }
    });
});