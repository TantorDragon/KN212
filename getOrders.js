(function getOrders() {
  var url = "https://localhost:5001/orders/all";
  var request = new XMLHttpRequest();
  request.open("GET", url);
  var jwtoken = getCookie("token");
  request.setRequestHeader("Content-type", "application/json");
  request.setRequestHeader('Authorization', 'Bearer ' + jwtoken);
  request.setRequestHeader("Access-Control-Allow-Origin", "*");
  request.send();
  request.onload = function () {
    var result = JSON.parse(request.responseText);
    document.getElementById("tableBody");
    var i;
    for (i = 0; i < result.length; i++) {
      var trNode = document.createElement("tr");
      trNode.appendChild(createTdNode(result[i].id))
      trNode.appendChild(createTdNode(result[i].clientName));
      trNode.appendChild(createTdNode(result[i].phoneNumber));
      trNode.appendChild(createTdNode(result[i].email));
      trNode.appendChild(createTdNode(result[i].orderType));
      trNode.appendChild(createTdNode(result[i].description));
      trNode.appendChild(createTdNode(formatDate(result[i].dateCreated)));
      trNode.appendChild(createTdWithOnClick(result[i].isActive));
      document.getElementById("tableBody").appendChild(trNode);
    }
  }
})()

function createTdNode(data) {
  var td = document.createElement("td");
  td.innerHTML = data;
  return td;
}

function createTdWithOnClick(data) {
  var td = document.createElement("td");
  var button = document.createElement("button");
  button.onclick = function(){ deactivateOrder(this) };
  button.innerText = data;
  button.className = "isActiveButton";
  td.appendChild(button);
  return td;
}

function deactivateOrder(element) {
  var order = getOrderFromHTML(element);
  order.isActive = order.isActive=="true" ? false : true;
  var url = "https://localhost:5001/orders";
  var request = new XMLHttpRequest();
  request.open("PUT", url);
  var jwtoken = getCookie("token");
  request.setRequestHeader("Content-type", "application/json");
  request.setRequestHeader('Authorization', 'Bearer ' + jwtoken);
  request.setRequestHeader("Access-Control-Allow-Origin", "*");
  request.send(JSON.stringify(order));
  request.onload = function () {
    if (request.status != 204) {
      alertify.alert("Cannot update order.");
    } else {
      alertify.success('Success!');
      if(element.innerText == "true")
      {
        element.innerText = "false";
        element.classList.add("nonActive");
      }
      else
      {
        element.innerText = "true";
        element.classList.remove("nonActive");
      }
    }
  }
}

function getOrderFromHTML(element) {
  var nodes = element.parentNode.parentNode.children;
  var id = nodes[0].innerHTML;
  var clientName = nodes[1].innerHTML;
  var phoneNumber = nodes[2].innerHTML;
  var email = nodes[3].innerHTML;
  var orderType = nodes[4].innerHTML;
  var description = nodes[5].innerHTML;
  var dateCreated = nodes[6].innerHTML;
  var isActive = nodes[7].innerText;

  return {
    id: parseInt(id),
    clientName: clientName,
    phoneNumber: phoneNumber,
    email: email,
    orderType: orderType,
    description: description,
    dateCreated: dateCreated + "T00:00:00",
    isActive: isActive
  };
}

function getCookie(cname) {
  var name = cname + "=";
  var decodedCookie = decodeURIComponent(document.cookie);
  var ca = decodedCookie.split(';');
  for (var i = 0; i < ca.length; i++) {
    var c = ca[i];
    while (c.charAt(0) == ' ') {
      c = c.substring(1);
    }
    if (c.indexOf(name) == 0) {
      return c.substring(name.length, c.length);
    }
  }
  return "";
}

function formatDate(date) {
  var d = new Date(date),
    month = '' + (d.getMonth() + 1),
    day = '' + d.getDate(),
    year = d.getFullYear();

  if (month.length < 2)
    month = '0' + month;
  if (day.length < 2)
    day = '0' + day;

  return [year, month, day].join('-');
}