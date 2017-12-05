
$(document).ready(function getInformation() {
    var hostname = document.location.host;
    // check if there is a cookie valid.
    if (isCookieValid()) {
        $("#logindropdownnavbar").get(0).hidden = true;
        $("#signupnavbar").get(0).hidden = true;
        $("#mypagenavbar").get(0).hidden = false;
        $("#logoutbutton").get(0).hidden = false;


    }

    $("#mypagenavbar").click(function () {
        var cookie = document.cookie;
        var rank = cookie.split("=")[1];
        switch (rank) {
            case "301":
                document.location.pathname = "teamPage.html";
                break;
            case "355":
                document.location.pathname = "judgePage.html";
                break;
            case "395":
                document.location.pathname = "adminPage.html";
                break;
            default:
        }


    });

    $.ajax({
        url: 'http://' + hostname + '/api/Tournaments', success: function (result) {
            var address = result[result.length - 1].fldAddress;
            $("#placeinformation").html(address)
        }
    });
    $.ajax({
        url: 'http://' + hostname + '/api/Tournaments', success: function (result) {
            var endTime = result[result.length - 1].fldEndDate;
            $("#endtimeinformation").html(formatDateTime(endTime))
        }
    });
    $.ajax({
        url: 'http://' + hostname + '/api/Tournaments', success: function (result) {
            var startTime = result[result.length - 1].fldStartDate;
            $("#starttimeinformation").html(formatDateTime(startTime));
        }
    });



});

function formatDateTime(datetime) {
    var datetimeWithOutT = datetime.replace("T", " ");
    var parts = datetimeWithOutT.split(/[- :]/);
    var wanted = parts[2] + '/' + parts[1] + '/' + parts[0] + ' ' + parts[3] + ':' + parts[4];
    return wanted;
}

function isCookieValid() {
    console.log(document.cookie);
    if (document.cookie.length > 0) {
        return true;
    }
    return false;
}
