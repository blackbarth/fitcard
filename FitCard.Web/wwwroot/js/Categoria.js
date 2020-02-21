
var ConfirmDelete = function (Id) {

    $("#hiddenId").val(Id);
    $("#myModal").modal('show');

}

var ExcluirCategoria = function () {



    var empId = $("#hiddenId").val();

    $.ajax({

        type: "POST",
        url: "/Categorias/Delete",
        data: { Id: empId },
        success: function (result) {

            $("#myModal").modal("hide");
            $("#row_" + empId).remove();
            window.location.reload();
        }

    })

}