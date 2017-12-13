$(document).ready(function () {

    // Showing modal when clicking create new question.
    $("#createReportQuestionButton").click(function () {
        $("#modalTitle").text("Creating question for " + $("#dropdown").val());
        $("#CreateNewQuestionModal").modal();
    });

    $("#createQuestionBtn").click(function () {
    
        var data = {
            fldQuestion: $("#Question").val(),
            fldModifier: $("#Modifier").val(),
            fldQuestionnaireID: $("#dropdown").val();
        };
        alert(JSON.stringify(data));


    });

});


