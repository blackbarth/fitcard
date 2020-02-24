var ConfirmDelete = function (id) {
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
    $("#EmpresaDataCadastro").mask("99/99/9999");

    $('#EmpresaDataCadastro').blur()
    {

    };

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

    $('#EmpresaDataCadastro').blur(function () {
        var dateformat = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
        var Val_date = $('#txt_date').val();
        if (Val_date.match(dateformat)) {
            var seperator1 = Val_date.split('/');
            var seperator2 = Val_date.split('-');

            if (seperator1.length > 1) {
                var splitdate = Val_date.split('/');
            }
            else if (seperator2.length > 1) {
                var splitdate = Val_date.split('-');
            }
            var dd = parseInt(splitdate[0]);
            var mm = parseInt(splitdate[1]);
            var yy = parseInt(splitdate[2]);
            var ListofDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            if (mm == 1 || mm > 2) {
                if (dd > ListofDays[mm - 1]) {
                    alert('Formato de data invalido!');
                    return false;
                }
            }
            if (mm == 2) {
                var lyear = false;
                if ((!(yy % 4) && yy % 100) || !(yy % 400)) {
                    lyear = true;
                }
                if ((lyear == false) && (dd >= 29)) {
                    alert('Formato de data invalido!');
                    return false;
                }
                if ((lyear == true) && (dd > 29)) {
                    alert('Formato de data invalido!');
                    return false;
                }
            }
        }
        else {
            alert("Formato de data invalido!");

            return false;
        }
    });

});
