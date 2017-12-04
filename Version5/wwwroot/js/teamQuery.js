
function checkLogin() {
    if (document.cookie.length > 0) {
        alert(document.location.pathname);
        var cookie = document.cookie;
        var rank = cookie.split("=")[1];
        if (rank == "301" || rank == "395") {

        } else {
            $('#bodyid').get(0).hidden = true;
            alert("Not allowed");
        }
    } else {
        $('#bodyid').get(0).hidden = true;
        alert("Not allowed");
    }

}


