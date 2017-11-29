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
                url: 'http://localhost:55655/api/projects',
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
            };
            $.ajax({
                url: 'http://localhost:55655/api/logins',
                method: 'POST',
                contentType: "application/json",
                data: JSON.stringify(LoginData),
                success: function () {
                    alert("Login create Success");
                    createTeam()
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
                fldLeaderName: $('#TeamLeader').val(),
            }
            $.ajax({
                url: 'http://localhost:55655/api/teams',
                method: 'POST',
                contentType: "application/json",
                data:JSON.stringify(TeamData),
                success: function () {
                    alert("Team has been registered. Please log in to continue");
                    window.location.href = "index.html";

                },
                error: function () {
                    alert("Team create Failed");
                }
            })
        }


        //Register Team
        $.ajax({
            url: "http://localhost:55655/api/tournaments",
            type: "GET",
            contentType: "application/json",
            dataType: "json",
        }).then(function (data) {
            alert("TournamentID = " + data[data.length - 1].fldTournamentId);
            TournamentID = data[data.length - 1].fldTournamentId;
        }).then(function () {
            createProject()
        });

    })
})