const checkbox = document.getElementById('checkbox');
const intro = document.getElementById('intro');
const costumers = document.getElementById('costumers');
const costumers__items = document.querySelectorAll('.costumers__item');
const price = document.getElementById('price');
const price__table = document.getElementById('price__table');
const header = document.getElementById('header');
const footer = document.getElementById('footer');

checkbox.addEventListener('change',()=>{
    document.body.classList.toggle('dark');
    intro.classList.toggle('dark');
    costumers.classList.toggle('dark');
    costumers__items.forEach(item => {
    item.classList.toggle('dark');
    });
    price.classList.toggle('dark');
    price__table.classList.toggle('dark');
    header.classList.toggle('dark');
    footer.classList.toggle('dark');
});