function gerarNumeroMatricula() {
    var data_nascimento = document.getElementById("campo-data-nascimento").value;
    var replace_data_nascimento = data_nascimento.replace(/-/g, "");
    document.getElementById("campo-codigo-matricula").value = replace_data_nascimento + random();
}

function contaFrequencia(){
    var faltas = document.getElementById("campo-faltas").value;
    var conta = ((faltas * 100) / 200);
    var frequencia = 100 - conta
    document.getElementById("campo-frequencia").value = frequencia + "%";
}

function random() {
    return Math.floor(Math.random() * 1000)
}

function media() {
    var nota1 = parseFloat(document.getElementById("campo-nota-1").value);
    var nota2 = parseFloat(document.getElementById("campo-nota-2").value);
    var nota3 = parseFloat(document.getElementById("campo-nota-3").value);
    var media = parseFloat((nota1 + nota2 + nota3) / 3);
    var media_formatada = media.toFixed(2)
    var media_virgula = media_formatada.replace(".", ",");
    document.getElementById("campo-media").value = media_virgula;
}

$(function () {

    $("#campo-nota-1").mask("00,00")
    $("#campo-nota-2").mask("00,00")
    $("#campo-nota-3").mask("00,00")

});

function liberar() {
    var nota1 = document.getElementById("campo-nota-1");
    var nota2 = document.getElementById("campo-nota-2");
    var nota3 = document.getElementById("campo-nota-3");

    if (nota1.value != "") {
        nota2.disabled = false;
    }

    if (nota2.value != "") {
        nota3.disabled = false;
    }
}

function validarCampoNome() {

    var textoCampoNome = document.getElementById("campo-nome").value;

    document.getElementById("campo-nome").classList.remove("border-success");

    apagarElemento("span-campo-nome-menor-7");
    apagarElemento("span-campo-nome-maior-100");

    if (textoCampoNome.length < 7) {

        var elementoSpanNome = document.createElement("span");
        var texto = document.createTextNode("Campo nome deve conter no mínimo 7 caracteres");
        elementoSpanNome.id = "span-campo-nome-menor-7";
        elementoSpanNome.appendChild(texto);
        elementoSpanNome.classList.add("text-danger");
        document.getElementById("div-campo-nome").appendChild(elementoSpanNome);
        document.getElementById("campo-nome").classList.add("border-danger");
        return false;

    }

    if (textoCampoNome.length > 100) {

        var elementoSpanNome = document.createElement("span");
        elementoSpanNome.textContent = "Nome deve conter no máximo 100 caracteres";
        elementoSpanNome.id = "span-campo-nome-maior-100";
        elementoSpanNome.classList.add("text-danger");
        document.getElementById("div-campo-nome").appendChild(elementoSpanNome);
        document.getElementById("campo-nome").classList.add("border-danger");
        return false;

    }

    if ((textoCampoNome.length >= 7) && (textoCampoNome.length <= 100)) {
        document.getElementById("campo-nome").classList.remove("border-danger");
        document.getElementById("campo-nome").classList.add("border-success");
        return true;
    }

}
