$(document).ready(function () {

    $("#CreateLogin").click(function () {

        var TournamentID;
        var loginID;
        var ProjectID;

        function getLoginID() {

            $.ajax({
                url: "http://localhost:55655/api/logins",
                type: "GET",
                contentType: "application/json",
                dataType: "json",
                success: function () {
                    alert("GotLoginID");
                }, error: function () {
                    alert("failedLoginID");
                }
            }).then(function (data) {
                for (var i = 0; i < data.length; i++) {
                    if ($('#email').val() === data[i].fldUsername) {
                        alert("LoginID = "+ data[i].fldLoginID);
                        loginID = data[i].fldLoginID;
                    }
                }
            });

        }
        function getProjectID() {
            $.ajax({
                url: "http://localhost:55655/api/projects",
                type: "GET",
                contentType: "application/json",
                dataType: "json"
            }).success(function (data) {
                for (var i = 0; i < data.length; i++) {
                    if ($('#projectname').val() == data[i].fldProjectName) {
                        alert("ProjectID = " + data[i].fldProjectName);
                        projectID = data[i].fldProjectName;
                    }
                }
            });
        }

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
                }, error: function () {
                    alert("Login create failure");
                }
            });
        }
        function createTeam() {
            $.ajax({
                url: 'http://localhost:55655/api/teams',
                method: 'POST',
                data: {
                    fldProjectID: ProjectID,
                    fldLoginID: loginID,
                    fldTeamName: $('#TeamName').val(),
                    fldTopic: $('#Category').val(),
                    fldMembers: 4,
                    fldLeaderName: $('#TeamLeader').val(),
                },
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
            success: function () {
                alert("Got Tournament ID");
            }
        }).then(function (data) {
            alert("TournamentID = " + data[data.length-1].fldTournamentId);
            TournamentID = data[data.length - 1].fldTournamentId;
        }).then(function () {
            createProject()
        }).then(function () {
            createLogin()
        }).then(function () {
            getLoginID()
        }).then(function () {
            getProjectID()
        }).then(function () {
            createTeam()
        })

    })
})





    //Posting the login information to the server.


    //// Posting the team information to the server.
    //$.ajax({
    //    url: 'http://localhost:55655/api/teams',
    //    method: 'POST',
    //    data: {
    //        fldProjectID: 1,
    //        fldLoginID: 1,
    //        fldTeamName: $('#TeamName').val(),
    //        fldTopic: $('#Category').val(),
    //        fldMembers: 4,
    //        fldLeaderName: $('#TeamLeader').val(),
    //    },
    //    success: function () {
    //        alert("Team has been registered. Please log in to continue");
    //        window.location.href = "index.html";

    //    },
    //    error: function () {
    //        alert("Failed");
    //    }

    //});










