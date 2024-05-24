function loadUserCredentials() {
    var user = localStorage.getItem("user");
    var password = localStorage.getItem("password");
    if (!!user && !!password) {
        $("#username").val(user);
        $("#password").val(password);
        $("#remember").prop("checked", true);
    }
}

function saveUserCredentials() {
    if ($("#remember").prop("checked") == true) {
        var user = $("#username").val();
        var password = $("#password").val();
        localStorage.setItem("user", user);
        localStorage.setItem("password", password);
    }
    else {
        localStorage.removeItem("user");
        localStorage.removeItem("password");
    }
}

window.addEventListener("load", loadUserCredentials, false);

$("#login").on("click", saveUserCredentials);