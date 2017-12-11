$(document).ready(function login() {
    var hostname = document.location.host;

    if (isCookieValid()) {
        var email = document.cookie.split("=")[0];

        $(".setLoggedInAs").text("Logged in as: " + email);



        $(".showWhenLoggedIn").show();
        $(".showWhenNotLoggedIn").hide();
    } else {
        $(".showWhenLoggedIn").hide();
        $(".showWhenNotLoggedIn").show();
    }

    $("#loginbutton").click(function () {
        var loginObject = {
            fldUsername: $('#Loginusername').val(),
            fldPassword: $('#Loginpassword').val()
        };
        if (isEmail(loginObject.fldUsername) && loginObject.fldPassword != null) {
            $.ajax({
                url: 'http://' + hostname + '/api/ValidateLogin',
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
                        switch (b.rank) {
                            case "301":
                                createCookie(loginObject.fldUsername, "301");
                                document.location.pathname = "teamPage.html";
                                break;
                            case "355":
                                createCookie(loginObject.fldUsername, "355");
                                document.location.pathname = "judgePage.html";
                                break;
                            case "395":
                                createCookie(loginObject.fldUsername, "395");
                                document.location.pathname = "adminPage.html";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 200:
                        alert(b.msg);
                        break;
                    case 300:
                        alert(b.msg);
                        break;
                    default:
                        alert("Unknown error");
                        break;
                }
            });
        } else {
            alert("You have write your username (email address) and your password to login");
        }
    });

    $("#mypagenavbar").click(function () {
        var cookie = document.cookie;
        var rank = cookie.split("=")[1];
        switch (rank) {
            case "301":
                document.location.pathname = "teamPage.html";
                break;
            case "355":
                document.location.pathname = "judgePage.html";
                break;
            case "395":
                document.location.pathname = "adminPage.html";
                break;
            default:
        }


    });

    $("#logoutbutton").click(function () {
        var cookie = document.cookie;
        var username = cookie.split("=")[0];
        document.cookie = username + "=; expires=Thu, 01 Jan 1970 00:00:01 GMT;";
        document.location.pathname = "index.html";
    });
});

function isCookieValid() {
    console.log(document.cookie);
    if (document.cookie.length > 0) {
        return true;
    }
    return false;
}

function createCookie(username, rank) {
    var expirationDay = "expires=" + new Date(new Date().getTime() + 60 * 60 * 24 * 1000);
    var time = expirationDay.split("+")[0];
    document.cookie = username + "=" + rank + ";" + "expires=" + time;
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