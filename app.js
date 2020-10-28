$(function () {
    let header = $("#header");
    let intro = $("#intro");
    let introH = intro.innerHeight();
    let scrollPos = $(window).scrollTop();

    $(window).on("scroll load resize", function () {
        introH = intro.innerHeight();
        scrollPos = $(this).scrollTop();
        if (scrollPos > introH) {
            header.addClass("fixed");
        } else {
            header.removeClass("fixed");
        }
    });
});

function CheckForm() {
    if (CheckFirstName() && CheckMail() && CheckNumber()) {
        alertify.success("Дякуємо за замовлення! Зв'яжемось з вами найближчим часом :)");
    }
}

function CheckFirstName() {
    let fnameValue = document.forms["form__inner"]["fname"].value;
    if (!IsLetter(fnameValue)) {
        alertify.warning("Некоректне ім'я!");
        return false;
    }
    return true;
}

function CheckNumber() {
    let numberValue = document.forms["form__inner"]["user-phone"].value;
    if (!IsNumber(numberValue) || Array.from(numberValue).length != 12) {
        alertify.warning("Введіть номер мобільного телефону у форматі 38 000 000 00 00!");
        return false;
    }
    return true;
}

function CheckMail() {
    var regex = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/;
    let mail = document.forms["form__inner"]["email"].value;
    if (mail.match(regex)) {
        return true;
    }
    else {
        alertify.warning("Некоректний email!");
        return false;
    }
}

function IsLetter(value) {
    var regex = /^[а-яА-Яі]+$/;
    if (value.match(regex)) {
        return true;
    }
    else {
        return false;
    }
}

function IsNumber(value) {
    return !isNaN(value);
}

function createOrder() {
    var name = document.getElementById("clientName").value;
    var email = document.getElementById("clientEmail").value;
    var phoneNumber = document.getElementById("clientNumber").value;
    var description = document.getElementById("orderDescription").value;
    var url = "https://localhost:5001/orders";
    var request = new XMLHttpRequest();
    request.open("POST", url);
    request.setRequestHeader("Access-Control-Allow-Origin", "*")
    request.setRequestHeader("Content-type", "application/json");
    request.send(JSON.stringify(
        {
            DateCreated: formatedNow() + "T00:00:00",
            PhoneNumber: phoneNumber,
            Email: email,
            OrderType: getOrderType(),
            Description: description,
            ClientName: name,
            IsActive: true
        }));
    request.onload = function () {
        if (request.status == 201) {
            alertify.success('Success!');
        }
        else {
            alertify.error('Cannot create an order.');
        }
    }
}

function formatedNow() {
    var d = new Date(),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return [year, month, day].join('-');
}

function getOrderType() {
    var nodes = document.getElementById("checkboxes").children;
    for (let i = 0; i < nodes.length; i++) {
        if (nodes[i].children[0].checked == true) {
            return nodes[i].children[0].value;
        }
    }

    return null;
}

function resetAll(element)
{
    var str = element.value;
    var nodes = document.getElementById("checkboxes").children;
    for (let i = 0; i < nodes.length; i++) {
        if (nodes[i].children[0].value != str) {
            nodes[i].children[0].checked = false;
        }
    }
}