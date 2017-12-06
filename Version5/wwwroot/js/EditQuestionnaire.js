$(document).ready(function () {

    getQuestions();




});


function getQuestions() {
    $.ajax({
        url: 'http://' + hostname + '/api/Questionaires',
        type: "GET",
        contentType: "application/json",
        dataType: "json",
    }).then(function (fromServer) {
        $('#table').bootstrapTable({
            data: fromServer
        });
    });
};
