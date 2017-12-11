$(document).ready(function() {
    var hostname = document.location.host;
    retrievingPlaceAndTimeData();

    $("#myCarousel").carousel({ interval: 5000 });
    $("#myCarousel").carousel({ pause: false });


    function retrievingPlaceAndTimeData() {
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
    }

    function formatDateTime(datetime) {
        var datetimeWithOutT = datetime.replace("T", " ");
        var parts = datetimeWithOutT.split(/[- :]/);
        var wanted = parts[2] + '/' + parts[1] + '/' + parts[0] + ' ' + parts[3] + ':' + parts[4];
        return wanted;
    }


});




