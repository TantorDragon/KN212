const anchors = document.querySelectorAll('a[href*="#"]');

for (let anchor of anchors) {
    anchor.addEventListener("click",function(event){
        event.preventDefault();
        const blockID = anchor.getAttribute('href');
        document.querySelector(''+blockID).scrollIntoView({
            behavior: "smooth",
            block: "start"
        })
    })
}

var cake = document.getElementById('cake');
var homecake = document.getElementById('home-cake');
var marshmallow = document.getElementById('marshmallow');
var cookies = document.getElementById('cookies');
var cupcakes = document.getElementById('cupcakes');
var muffins = document.getElementById('muffins');
var other = document.getElementById('other');

cake.addEventListener("dblclick", ()=>openWindow('https://mycakes'));
cake.addEventListener("mouseover",colored);
cake.addEventListener("mouseout",uncolored);

homecake.addEventListener("dblclick", ()=>openWindow('https://myhomecakes'));
homecake.addEventListener("mouseover",colored);
homecake.addEventListener("mouseout",uncolored);

marshmallow.addEventListener("dblclick", ()=>openWindow('https://mymarshmallow'));
marshmallow.addEventListener("mouseover",colored);
marshmallow.addEventListener("mouseout",uncolored);

cookies.addEventListener("dblclick", ()=>openWindow('https://mycookies'));
cookies.addEventListener("mouseover",colored);
cookies.addEventListener("mouseout",uncolored);

cupcakes.addEventListener("dblclick", ()=>openWindow('https://mycupcakes'));
cupcakes.addEventListener("mouseover",colored);
cupcakes.addEventListener("mouseout",uncolored);

muffins.addEventListener("dblclick", ()=>openWindow('https://mymuffins'));
muffins.addEventListener("mouseover",colored);
muffins.addEventListener("mouseout",uncolored);

other.addEventListener("dblclick", ()=>openWindow('https://myother'));
other.addEventListener("mouseover",colored);
other.addEventListener("mouseout",uncolored);

function openWindow(adress){
    window.open(adress);
}
function colored(){
    this.style.color='#e7843c';
}
function uncolored(){
    this.style.color='#6a6a6a';
}