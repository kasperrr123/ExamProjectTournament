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
