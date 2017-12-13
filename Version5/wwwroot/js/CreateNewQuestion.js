$(document).ready(function () {

    // Showing modal when clicking create new question. 
    // Click event for create quetion button for report.
    $("#createReportQuestionButton").click(function () {
        $("#modalTitle").text("Creating report question under category " + $("#dropdown").val());
        $("#hiddenLabelWithType").val("report");
        $("#CreateNewQuestionModal").modal();
    });
    // Showing modal when clicking create new question. 
    // Click event for create quetion button for interview.
    $("#createInterviewQuestionButton").click(function () {
        $("#modalTitle").text("Creating interview question under category " + $("#dropdown").val());
        $("#hiddenLabelWithType").val("interview");
        $("#CreateNewQuestionModal").modal();
    });
    // Click event firing ajax.
    $("#createQuestionBtn").click(function () {
        if ($("#Question").val() != "" && $("#Modifier").val() != "") {
            postQuestion();
        } else {
            ErrorMessageLogin("Error", "rgba(255, 0, 0, 1)");
        }

    });
    // Click event for close button on modal.
    $("#closeBtn").click(function () {
        location.reload(true);
    });

});

function postQuestion() {
    var data = {
        fldQuestion: $("#Question").val(),
        fldModifier: $("#Modifier").val(),
        fldQuestionnaireID: getQuestionaireID($("#hiddenLabelWithType").val())
    };
    $.ajax({
        url: 'http://' + hostname + '/api/questions',
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        dataType: "json",
        success: function () {
            fldQuestion: $("#Question").val("");
            fldModifier: $("#Modifier").val("");
            ErrorMessageLogin("Success", "rgba(0, 255, 0, 1)");
        }
    });
}
function ErrorMessageLogin(message, color) {
    document.getElementById("ErrorLoginBox").innerHTML = message + '<span class="closebtn" onclick="CloseX(this)">&times;</span>'
    var box = document.getElementById("ErrorLoginBox");
    box.style.backgroundColor = color;

    $("#ErrorLoginBox").fadeTo(100, 0.1).fadeTo(200, 1.0);
    $("#ErrorLoginBox").show();

}
function CloseX(button) {
    button.parentElement.style.display = 'none';
}
function getQuestionaireID(type) {
    var topic = $("#dropdown").val();
    if (type == "report") {
        switch (topic) {
            case 'Business & Service':
                return id = 1;

            case 'Science & Technology':
                return id = 2;

            case 'Trade & Skills':
                return id = 3;

            case 'Society & Globalization':
                return id = 4;

            default:
        }
    } else if (type == "interview") {
        switch (topic) {
            case 'Business & Service':
                return id = 5;

            case 'Science & Technology':
                return id = 6;

            case 'Trade & Skills':
                return id = 7;

            case 'Society & Globalization':
                return id = 8;

            default:
        }
    }

}


