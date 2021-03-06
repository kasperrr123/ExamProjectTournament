﻿
$(document).ready(function () {
    var hostname = document.location.host;

    var emailAvailable = false;
    var teamNameAvailable = false;
    var projectNameAvailable = false;
    var passwordAvailable = false;
    var teamLeaderAvailable = false;

    $("#email").focusout(function () {
        var fldUsername = $('#email').val();
        if (isEmail(fldUsername)) {
            $.ajax({
                url: 'http://' + hostname + '/api/logins',
                type: "GET",
                contentType: "application/json",
                dataType: "json",
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].fldUsername == fldUsername) {
                            var field = document.getElementById("email");
                            field.style.backgroundColor = "rgba(255, 0, 0, .3)";
                            emailAvailable = false;
                            break;

                        } else {
                            var field = document.getElementById("email");
                            field.style.backgroundColor = "rgba(0, 225, 0, .3)";
                            emailAvailable = true;
                        }
                    }

                },
                error: function () {
                    alert("Server error");
                }
            });
        } else {
            var field = document.getElementById("email");
            field.style.backgroundColor = "rgba(255, 0, 0, .3)";
        }

    });
    $("#TeamName").focusout(function () {
        var fldTeamName = $('#TeamName').val();
        $.ajax({
            url: 'http://' + hostname + '/api/teams',
            type: "GET",
            async: false,
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    if (data[i].fldTeamName.toLowerCase() == fldTeamName.toLowerCase()) {
                        var field = document.getElementById("TeamName");
                        field.style.backgroundColor = "rgba(255, 0, 0, .3)";
                        teamNameAvailable = false;
                        break;

                    } else {
                        var field = document.getElementById("TeamName");
                        field.style.backgroundColor = "rgba(0, 225, 0, .3)";
                        teamNameAvailable = true;
                    }
                }
            },
            error: function () {
                alert("Server error");
            }
        });
        if (fldTeamName == "") {
            var field = document.getElementById("TeamName");
            field.style.backgroundColor = "rgba(255, 0, 0, .3)";
        }
    });
    $("#projectname").focusout(function () {
        var fldProjectName = $('#projectname').val();
        $.ajax({
            url: 'http://' + hostname + '/api/teams',
            type: "GET",
            async: false,
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    if (data[i].fldProjectName.toLowerCase() == fldProjectName.toLowerCase()) {
                        var field = document.getElementById("projectname");
                        field.style.backgroundColor = "rgba(255, 0, 0, .3)";
                        projectNameAvailable = false;
                        break;

                    } else {
                        var field = document.getElementById("projectname");
                        field.style.backgroundColor = "rgba(0, 225, 0, .3)";
                        projectNameAvailable = true;
                    }
                }
            },
            error: function () {
                alert("Server error");

            }
        });

        if (fldProjectName == "") {
            var field = document.getElementById("projectname");
            field.style.backgroundColor = "rgba(255, 0, 0, .3)";
        }

    });
    $("#TeamLeader").focusout(function () {
        var field = document.getElementById("TeamLeader");
        var fldTeamLeader = $("#TeamLeader").val();
        if (fldTeamLeader == "") {
            field.style.backgroundColor = "rgba(255, 0, 0, .3)";
        } else {
            field.style.backgroundColor = "rgba(0, 255, 0, .3)";
            teamLeaderAvailable = true;
        }
    });
    $("#password").focusout(function () {
        var field = document.getElementById("password");
        var fldPassword = $("#password").val();
        if (fldPassword == "") {
            field.style.backgroundColor = "rgba(255, 0, 0, .3)";
        } else {
            field.style.backgroundColor = "rgba(0, 255, 0, .3)";
            passwordAvailable = true;

        }
    });

    $("#CreateLogin").click(function () {

        if (emailAvailable == true && teamNameAvailable == true && projectNameAvailable == true &&
        passwordAvailable == true && teamLeaderAvailable == true) {
        var TournamentID;
        //Register Team
        $.ajax({
            url: 'http://' + hostname + '/api/tournaments',
            type: "GET",
            contentType: "application/json",
            dataType: "json"
        }).then(function (data) {
            alert("TournamentID = " + data[data.length - 1].fldTournamentId);
            TournamentID = data[data.length - 1].fldTournamentId;
        }).then(function () {
            UploadFile();
        });

    } else {
        alert("You need to fill out the read areas");
    }

    function createProject(message) {
        var ProjectData = {
            fldTournamentID: TournamentID,
            fldProjectName: $('#projectname').val(),
            FldProjectFilePath: message
        };
        $.ajax({
            url: 'http://' + hostname + '/api/projects',
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
            url: 'http://' + hostname + '/api/logins',
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
    function getTopicID() {
        var topicID = 1;
        if ($('#Category').val() == "Science & Technology") {
            topicID = 2;
        } else if ($('#Category').val() == "Society & Globalization") {
            topicID = 4;
        } else if ($('#Category').val() == "Trade & Skills") {
            topicID = 3;
        }
        return topicID;
    }
    function createTeam() {
        var topicID = getTopicID();
        var TeamData = {
            fldProjectName: $('#projectname').val(),
            fldUsername: $('#email').val(),
            fldTeamName: $('#TeamName').val(),
            fldTopicID: topicID,
            fldLeaderName: $('#TeamLeader').val()
        };
        $.ajax({
            url: 'http://' + hostname + '/api/teams',
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
        alert("Uploadfile was run");
        var fileupload = $('#userfile').get(0);
        var files = fileupload.files;
        var data = new FormData();

        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }
        $.ajax({
            type: "POST",
            url: "/home/UploadFilesAjax",
            contentType: false,
            processData: false,
            data: data,
            success: function (message) {
                createProject(message);
            },
            error: function () {
                alert("there was error uploading files!");
            }
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



});

});















