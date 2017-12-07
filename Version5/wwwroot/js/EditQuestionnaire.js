var hostname = document.location.host;

$(document).ready(function () {
    var topic;
    $("#dropdown").change(function () {
        topic = $("#dropdown").val();
        getQuestions(topic);
    });
    getQuestions($("#dropdown").val());




});


function getQuestions() {
    var topic = $("#dropdown").val();

    var id, interviewID;
    switch (topic) {
        case 'Business & Service':
            id = 1;
            interviewID = 5;
            break;
        case 'Science & Technology':
            id = 2;
            interviewID = 6;
            break;
        case 'Trade & Skills':
            id = 3;
            interviewID = 7;
            break;
        case 'Society & Globalization':
            id = 4;
            interviewID = 8;
            break;
        default:
    }
    $.ajax({
        url: 'http://' + hostname + '/api/Questions/' + id,
        type: "GET",
        contentType: "application/json",
        dataType: "json",
    }).then(function (fromServer) {
        alert(JSON.stringify(fromServer));
        $('#tableReport').bootstrapTable({
            data: fromServer
        });

    });
    $.ajax({
        url: 'http://' + hostname + '/api/Questions/' + interviewID,
        type: "GET",
        contentType: "application/json",
        dataType: "json",
    }).then(function (fromServer) {
        alert(JSON.stringify(fromServer));

        $('#tableInterview').bootstrapTable({
            data: fromServer
        });
    });


}
