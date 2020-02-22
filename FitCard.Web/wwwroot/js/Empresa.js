﻿var ConfirmDelete = function (id) {
    $("#hiddenId").val(id);
}

var DeleteRegistro = function () {

    var _id = $("#hiddenId").val();
    $.ajax({
        type: "POST",
        url: "/Empresas/Delete",
        data: { Id: _id },
        success: function (result) {
            window.location.reload();
        }
    });
}

$(document).ready(function () {


    $("#EmpresaCNPJ").mask("99.999.999/9999-99");
    $("#EmpresaAgencia").mask("999-9");
    $("#EmpresaConta").mask("99.999-9");


    $("#EmpresaTelefone")
        .mask("(99) 99999-9999")
        .focusout(function (event) {
            var target, phone, element;
            target = (event.currentTarget) ? event.currentTarget : event.srcElement;
            phone = target.value.replace(/\D/g, '');
            element = $(target);
            element.unmask();
            if (phone.length > 10) {
                element.mask("(99) 99999-9999");
            } else {
                element.mask("(99) 99999-9999");
            }
        });

});

