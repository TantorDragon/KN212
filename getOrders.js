function getOrders(document)
{
    var url = "http://localhost:5000/orders";
    var XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;
    var request = new XMLHttpRequest();
    request.open("GET", url, true);
    request.send();
    var result = JSON.parse(request.responseText);
    document.getElementById("tableBody");
    var i;
    for(i = 0; i<result.length; i++){
        var trNode = document.createElement("tr");
        trNode.appendChild(createTdNode(result[i].Name));
        trNode.appendChild(createTdNode(result[i].PhoneNumber));
        trNode.appendChild(createTdNode(result[i].Email));
        trNode.appendChild(createTdNode(result[i].OrderType));
        trNode.appendChild(createTdNode(result[i].Description));
        document.getElementById("tableBody").appendChild()
    }
}

function createTdNode(data)
{
    var td = document.createElement("td");
    td.innerHTML = data;
    return td;
}