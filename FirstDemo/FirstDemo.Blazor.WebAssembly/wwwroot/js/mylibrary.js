console.log("Hello from mylibrary.js");
window.somma = function(a, b) {
    return a + b;
}

window.saluta = function (nome) {
    DotNet.invokeMethodAsync("FirstDemo.Blazor.UI", "Saluta", nome)
        .then(function (saluto) {
            console.log(saluto);
        });   
}

window.ola = function (hellohelper) {
    hellohelper.invokeMethodAsync("SayHello")
        .then(x => console.log(x));      ;
}


var x = somma(2, 3);
console.log(window);