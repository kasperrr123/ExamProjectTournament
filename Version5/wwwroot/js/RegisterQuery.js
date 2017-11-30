$(document).ready(function () {

    $("#CreateLogin").click(function () {

        var TournamentID;

        function createProject() {
            var ProjectData = {
                fldTournamentID: TournamentID,
                fldProjectName: $('#projectname').val(),
                fldData: null
            };
            $.ajax({
                url: 'http://kjdcyoungenterprice.azurewebsites.net/api/projects',
                method: 'POST',
                contentType: "application/json",
                data: JSON.stringify(ProjectData),
                success: function () {
                    alert("Project create Success");
                    createLogin();
                }, error: function () {
                    alert("Project create failure");
                }
            });
        }
        function createLogin() {
            var LoginData = {
                fldUsername: $('#email').val(),
                fldPassword: $('#password').val(),
                fldRank: 301
            };
            $.ajax({
                url: 'http://kjdcyoungenterprice.azurewebsites.net/api/logins',
                method: 'POST',
                contentType: "application/json",
                data: JSON.stringify(LoginData),
                success: function () {
                    alert("Login create Success");
                    createTeam();
                }, error: function () {
                    alert("Login create failure");
                }
            });
        }
        function createTeam() {
            var TeamData = {
                fldProjectName: $('#projectname').val(),
                fldUsername: $('#email').val(),
                fldTeamName: $('#TeamName').val(),
                fldTopic: $('#Category').val(),
                fldMembers: 4,
                fldLeaderName: $('#TeamLeader').val()
            };
            $.ajax({
                url: 'http://kjdcyoungenterprice.azurewebsites.net/api/teams',
                method: 'POST',
                contentType: "application/json",
                data: JSON.stringify(TeamData),
                success: function () {
                    alert("Team has been registered. Please log in to continue");
                    window.location.href = "index.html";

                },
                error: function () {
                    alert("Team create Failed");
                }
            });
        }
        function UploadFile() {
            $(function () {
                $('#projectfile').fileupload({
                    add: function (e, data) {
                        var jqXHR = data.submit()
                            .success(function (result, textStatus, jqXHR) {/* ... */
                                $('#insertPicture').val(result);
                                alert("File Uploaded");
                            })
                            .error(function (jqXHR, textStatus, errorThrown) {/* ... */
                                alert(errorThrown);
                            });
                    }
                });
            });
        }
        function isEmail(emailV) {
            if (emailV != null && emailV != undefined) {
                var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
                return pattern.test(emailV);
            }
            else {
                return false;
            }

        }


        //Register Team
        if (isEmail($('#email').val())) {
            $.ajax({
                url: "http://kjdcyoungenterprice.azurewebsites.net/api/tournaments",
                type: "GET",
                contentType: "application/json",
                dataType: "json"
            }).then(function (data) {
                alert("TournamentID = " + data[data.length - 1].fldTournamentId);
                TournamentID = data[data.length - 1].fldTournamentId;
            }).then(function () {
                createProject();
            }); 
        }
    });
});