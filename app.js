$(function() {
    let header=$("#header"); 
    let intro=$("#intro");
    let introH=intro.innerHeight();
    let scrollPos=$(window).scrollTop();
    
    $(window).on("scroll load resize", function(){
        introH=intro.innerHeight();
        scrollPos=$(this).scrollTop();
        if(scrollPos>introH){
            header.addClass("fixed");
        }else{
            header.removeClass("fixed");
        }
    });
});

function CheckForm(){
    if(CheckFirstName() && CheckMail() && CheckNumber())
    {
        alert("Дякуємо за замовлення! Зв'яжемось з вами найближчим часом :)");
    }
}

function CheckFirstName()
{
    let fnameValue = document.forms["form__inner"]["fname"].value;
    if(!IsLetter(fnameValue))
    {
        alert("Некоректне ім'я!");
        return false;
    }
    return true;
}

function CheckNumber(){
    let numberValue = document.forms["form__inner"]["user-phone"].value;
    if(!IsNumber(numberValue) || Array.from(numberValue).length != 12){
        alert("Введіть номер мобільного телефону у форматі 380 000 000 00 00!");
        return false;
    }
    return true;
}

function CheckMail(){
    var regex = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/;
    let mail = document.forms["form__inner"]["email"].value;
    if (mail.match(regex))
    {
        return true;
    }
    else
    {
        alert("Некоректний email!");
        return false;
    }
}

function IsLetter(value){
    var regex=/^[а-яА-Яі]+$/;
    if (value.match(regex))
    {
        return true;
    }
    else
    {
        return false;
    }
}

function IsNumber(value){
    return !isNaN(value);
}

function createOrder()
{
    var name = document.getElementById("clientName").value;
    var email = document.getElementById("clientEmail").value;
    var phoneNumber = document.getElementById("clientNumber").value;
    var description = document.getElementById("orderDescription").value;
    var url = "https://localhost:5000/orders";
    var request = new XMLHttpRequest();
    request.open("POST", url, true);
    request.setRequestHeader("Access-Control-Allow-Origin", "*")
    request.send(JSON.stringify(
        {
            DateCreated = new Date().toLocaleString().replace(",",""),
            PhoneNumber = phoneNumber,
            Email = email,
            OrderType = orderType,
            Description = description,
            ClientName = name,
            IsActive = true
        }));
    if(request.status == 201)
    {
        //successfull
    }
    else
    {
        //something went wrong
    }
}