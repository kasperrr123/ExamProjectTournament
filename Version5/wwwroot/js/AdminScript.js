$(document).ready(function () {
    var hostname = document.location.host;
    //alert("Inside AdminScript");

    var collectionOfTeams = getTeams();





    function getTeams() {
        var collectionOfTeams = [];
        $.ajax({
            url: 'http://' + hostname + '/api/GetFldTeamName',
            type: "GET",
            contentType: "application/json",
            dataType: "json",
        }).then(function (fromServer) {

            for (var i = 0; i < length; i++) {


                var data = {
                    time: "9.20",
                    judgea: judgeAData,
                    judgeb: judgeBData,
                    judgec: judgeCData,
                    judged: judgeDData,
                    judgee: judgeEData,
                    judgef: judgeFData,
                    judgeg: judgeGData,
                    judgeh: judgeHData,
                    judgei: judgeIData,
                    judgej: judgeJData,
                    judgek: judgeKData,
                    judgel: judgeLData
                };

                collectionOfTeams[0] = data;
            }


            $('#table').bootstrapTable({
                data: fromServer
            });
        });




    };


});







