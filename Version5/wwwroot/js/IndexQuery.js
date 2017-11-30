var sessionToken;

$(document).ready(function getInformation() {
    $.ajax({
        url: "http://kjdcyoungenterprice.azurewebsites.net/api/Tournaments", success: function (result) {
            var address = result[result.length - 1].fldAddress;
            $("#placeinformation").html(address)
        }
    });
    $.ajax({
        url: "http://kjdcyoungenterprice.azurewebsites.net/api/Tournaments", success: function (result) {
            var endTime = result[result.length - 1].fldEndDate;
            $("#endtimeinformation").html(formatDateTime(endTime))
        }
    });
    $.ajax({
        url: "http://kjdcyoungenterprice.azurewebsites.net/api/Tournaments", success: function (result) {
            var startTime = result[result.length - 1].fldStartDate;
            $("#starttimeinformation").html(formatDateTime(startTime));
        }
    });


});

$(document).ready(function login() {
    $("#loginbutton").click(function () {

        $.ajax({
            url: "http://kjdcyoungenterprice.azurewebsites.net/api/logins",
            type: "GET",
            contentType: "application/json",
            dataType: "json"
        }).then(function (data) {
            var ifvalid = false;
            for (var i = 0; i < data.length; i++) {
                if ($("#username").val() == data[i].fldUsername && $("#password").val() == data[i].fldPassword) {
                    alert(data[i].fldRank);
                    ifvalid = true;
                }
            }
            if (!ifvalid) {
                alert("Email or password is incorrect. try again.")
            }

        })


    });
});




function formatDateTime(datetime) {
    var datetimeWithOutT = datetime.replace("T", " ");
    var parts = datetimeWithOutT.split(/[- :]/);
    var wanted = parts[2] + '/' + parts[1] + '/' + parts[0] + ' ' + parts[3] + ':' + parts[4];
    return wanted;
}