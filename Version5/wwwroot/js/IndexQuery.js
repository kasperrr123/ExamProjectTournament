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

