$(document).ready(function login() {
    $("#loginbutton").click(function () {
        var loginObject = {
            fldUsername: $('#Loginusername').val(),
            fldPassword: $('#Loginpassword').val(),
        }
        if (isEmail(loginObject.fldUsername) && loginObject.fldPassword != null) {
            $.ajax({
                url: "http://localhost:55655/api/ValidateLogin",
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify(loginObject)
            }).then(function (data) {
                var a = JSON.stringify(data);
                var b = JSON.parse(a);
                switch (b.status) {
                    case 100:
                        alert("You've been logged in: " + b.rank);
                        break;
                    case 200:
                        alert(b.msg);
                    case 300:
                        alert(b.msg);
                    default:
                        alert("Unknown error");
                        break;
                }
            });
        } else {
            alert("You have write your username (email address) and your password to login")
        }
    });
});




function formatDateTime(datetime) {
    var datetimeWithOutT = datetime.replace("T", " ");
    var parts = datetimeWithOutT.split(/[- :]/);
    var wanted = parts[2] + '/' + parts[1] + '/' + parts[0] + ' ' + parts[3] + ':' + parts[4];
    return wanted;
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