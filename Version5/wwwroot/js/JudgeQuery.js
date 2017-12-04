$(document).ready(function () {
    var hostname = document.location.host;
    function GetLinkFromTeamName(Teamname) {
        $.ajax({
            url: hostname +'/api/teams'
        })

        $.ajax({
            url: hostname +'api/projects',
            method: 'get',
            contentType: "application/json",
            success: function (data) {
                alert("Project create Success");
            }, error: function () {
                alert("Project create failure");
            }
        });
    }
})