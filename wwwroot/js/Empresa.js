//$(document).ready(function () {

//    $('#EmpresaTelefone').mask('(00) 0000-0000'); //mask with dynamic syntax
//    //$('#EmpresaCNPJ').mask('000.000.000-00', '00.000.000/0000-00');
//    $('#EmpresaCNPJ').mask('00.000.000/0000-00');

//    $('#EmpresaAgencia').mask('000-0', { keepStatic: true });

//    $('#EmpresaConta').mask('00.000-0');
//    $('#DataCadastro').mask('00/00/0000');

//});


$(function () {

    //$('#EmpresaCNPJ').blur(function () {

    //    // O CPF ou CNPJ
    //    var cpf_cnpj = $(this).val();

    //    // Testa a validação
    //    if (!valida_cpf_cnpj(cpf_cnpj)) {
    //        alert('CPF ou CNPJ inválido!');
    //        $('#EmpresaCNPJ').focus();
    //        return false;

    //    }

    //});

    //$('#EmpresaDataCadastro').blur(function () {

    //    // O CPF ou CNPJ
    //    var data = $(this).val();

    //    // Testa a validação
    //    if (!ValidaData(data)) {
    //        alert('Data inválida!');
    //        $('#EmpresaDataCadastro').focus();
    //        return false;

    //    }

    //});

});

$("#form").submit(function () {

    //var cpf_cnpj = $('#EmpresaCNPJ').val();

    //// Testa a validação
    //if (!valida_cpf_cnpj(cpf_cnpj)) {
    //    alert('CPF ou CNPJ inválido!');
    //    $('#EmpresaCNPJ').focus();
    //    return false;
    //}

    //var data = $('#EmpresaDataCadastro').val();

    //// Testa a validação
    //if (!ValidaData(data)) {
    //    alert('Data inválida!');
    //    $('#EmpresaDataCadastro').focus();
    //    return false;

    //}

    //var categoria = $('#CategoriaId').val();
    //if (categoria === 1) {
    //    alert("Obrigatório Preencher Telefone!");
    //    $('#CategoriaId').focus();
    //    return false;
    //}

});

function ValidaData(data) {
    reg = /[^\d\/\.]/gi;                  // Mascara = dd/mm/aaaa | dd.mm.aaaa
    var valida = data.replace(reg, '');    // aplica mascara e valida só numeros
    if (valida && valida.length == 10) {  // é válida, então ;)
        var ano = data.substr(6),
            mes = data.substr(3, 2),
            dia = data.substr(0, 2),
            M30 = ['04', '06', '09', '11'],
            v_mes = /(0[1-9])|(1[0-2])/.test(mes),
            v_ano = /(19[1-9]\d)|(20\d\d)|2100/.test(ano),
            rexpr = new RegExp(mes),
            fev29 = ano % 4 ? 28 : 29;

        if (v_mes && v_ano) {
            if (mes == '02') return (dia >= 1 && dia <= fev29);
            else if (rexpr.test(M30)) return /((0[1-9])|([1-2]\d)|30)/.test(dia);
            else return /((0[1-9])|([1-2]\d)|3[0-1])/.test(dia);
        }
    }
    return false                           // se inválida :(
}