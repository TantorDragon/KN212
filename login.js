function login(e) {
    e.preventDefault();
    var username = document.getElementById("un").value;
    var password = document.getElementById("pass").value;
    var url = 'https://localhost:5001/auth/login';

    var xhr = new XMLHttpRequest();
    xhr.open("POST", url);
    xhr.setRequestHeader("Content-type", "application/json");
    var user = { Password: password, Login: username };

    xhr.send(JSON.stringify(user));

    xhr.onload = function () {

        if (xhr.status != 200) {
            alertify.error("Bad password or login.");
        } else {
            document.cookie = "token=" + JSON.parse(xhr.responseText).token + ";path=/";
            window.location.href = "orders.html";
        }

    }
}