function login(e) {
    e.preventDefault();
    var username = document.getElementById("un").value;
    var password = document.getElementById("pass").value;
    var url = 'https://localhost:5001/auth/login';
    // var request = new XMLHttpRequest();
    // request.open("POST", url, true);
    // request.setRequestHeader("Access-Control-Allow-Origin", "*")
    // request.send(JSON.stringify({ Password: password, Login: username }));
    // request.onreadystatechange = function () {
    //     if (request.readyState != 4) return;

    //     if (request.status != 200) {
    //         alert(request.status + ': ' + request.statusText);
    //     } else {

    //         document.cookie = "token=" + JSON.parse(request.responseText.token)
    //     }

    // }

    debugger
    var xhr = new XMLHttpRequest();
    xhr.open("POST", url);
    xhr.setRequestHeader("Content-type", "application/json");
    var user = { Password: password, Login: username };

    xhr.send(JSON.stringify(user));

    xhr.onload = function () {

        if (xhr.status != 200) {
            alert(xhr.status + ': ' + xhr.statusText);
        } else {
            document.cookie = "token=" + JSON.parse(xhr.responseText).token + ";path=/";
            window.location.href = "orders.html";
        }

    }
}