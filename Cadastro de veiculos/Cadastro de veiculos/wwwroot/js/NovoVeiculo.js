function toUpperCase(elementId) {
    var element = document.getElementById(elementId);
    if (element) {
        element.value = element.value.toUpperCase();
    }
}

var input = document.getElementById("pesquisa");


input.addEventListener("input", function (event) {
    this.value = this.value.toUpperCase();
});