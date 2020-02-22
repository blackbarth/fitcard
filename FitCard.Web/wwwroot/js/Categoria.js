var ConfirmDelete = function (id) {
    $("#hiddenId").val(id);
}

var DeleteRegistro = function () {

    var _id = $("#hiddenId").val();
    $.ajax({
        type: "POST",
        url: "/Categorias/Delete",
        data: { Id: _id },
        success: function (result) {
            window.location.reload();
        }
    });
}