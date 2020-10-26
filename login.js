function login()
{
    var username = document.getElementById("un").value;
    var password = document.getElementById("pass").value;
    var url = "https://localhost:5001/auth/login";
    var request = new XMLHttpRequest();
    request.open("POST", url, true);
    request.setRequestHeader("Access-Control-Allow-Origin", "*")
    request.send(JSON.stringify({password: password, username: username }));
    if(request.status==200)
    {
        document.cookie = "token="+JSON.parse(request.responseText.token)
    }
    window.location.href = "orders.html"
}