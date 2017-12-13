var hostname = document.location.host;
var selectedRow;

$(document).ready(function () {

    // Double clicking a row inside the manage table. Opening user settings inside modal.
    $("#manageLoginsTable").on('click-row.bs.table', function (row, element, field) {
        var row = JSON.stringify(element);
        selectedRow = JSON.parse(row);
        $("#myModal").modal();

    });

    // Delete user handler.
    $("#DeleteUserBtn").click(function () {
        $("#deleteUserHeadline").text("Are you sure you want to delete user: " + selectedRow.fldUsername + " ?");
        $("#deleteUserModal").modal();
    });
    // when user has clicked yes to delete a user.
    // This function deletes the TEAM AND LOGIN and if the user is trying to delete a judge, it will only delete
    // the login.
    $("#YesBtn").click(function () {
        // Getting information from the table.
        var username = selectedRow.fldUsername;
        var rank = selectedRow.fldRank;
        alert(rank);
        if (rank == 355) {
            // Delete login.
            $.ajax({
                url: 'http://' + hostname + '/api/logins/' + username,
                type: "DELETE",
                contentType: "application/json",
                dataType: "json",
                success: function (data) {
                    alert("Login deleted")
                },
                error: function (data) {
                    alert("Login deleted failed");
                }
            });
        } else {
            // The login has a foreing key in tblTeam, so we have to delete both records.
            // We need the primarykey of tblTeam, so we wind that with the help of fldUserName, which we get from
            // the table.
            $.ajax({
                url: 'http://' + hostname + '/api/teams',
                type: "GET",
                contentType: "application/json",
                dataType: "json"
            }).then(function (dataFromServer) {
                // now we have the objects from the table.
                var json = JSON.stringify(dataFromServer);
                var collectionOfTeams = JSON.parse(json);
                // Goes through a forloop to find the exact team which have the same username. That way we can find
                // the correct fldTeamName we want to delete.
                for (var i = 0; i < collectionOfTeams.length; i++) {
                    if (username === collectionOfTeams[i].fldUsername) {
                        // Deleting the team.
                        $.ajax({
                            url: 'http://' + hostname + '/api/teams/' + collectionOfTeams[i].fldTeamName,
                            type: "DELETE",
                            contentType: "application/json",
                            dataType: "json",
                            success: function () {
                                alert("Team deleted")
                            }
                        }).then(function () {
                            // Deleting login now.
                            $.ajax({
                                url: 'http://' + hostname + '/api/logins/' + username,
                                type: "DELETE",
                                contentType: "application/json",
                                dataType: "json",
                                success: function (data) {
                                    alert("Login deleted")
                                },
                            });
                        });

                    }

                    break;


                }

            });

        }

    });

    // Show password handler.
    $("#ShowPasswordBtn").click(function () {
        $("#EnterPasswordForShowingPassword").modal();
    });
    // Showing password.
    $("#showBtn").click(function () {


        var typedPassword = $("#password").val() + "," + selectedRow.fldUsername;
        $.ajax({
            url: 'http://' + hostname + '/api/ValidateLogin/showEncryptedPassword/' + typedPassword,
            type: "GET",
            contentType: "application/json",
            dataType: "json"
        }).then(function (dataFromServer) {
            if (dataFromServer != null) {
                $("#fieldForPassword").text("Password for user: " + selectedRow.fldUsername + " is " + dataFromServer);
                $("#ModalForShowingPassword").modal();
                $("#password").val("");

            } else {
                alert("Wrong password");
                $("#password").val("");

            }
        });


    });

});
