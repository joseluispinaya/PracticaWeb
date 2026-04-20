
let tablaData;
let idEditar = 0;

$(document).ready(function () {

    listaCategorias();
});

function listaCategorias() {
    if ($.fn.DataTable.isDataTable("#tbCategoria")) {
        $("#tbCategoria").DataTable().destroy();
        $('#tbCategoria tbody').empty();
    }

    tablaData = $("#tbCategoria").DataTable({
        responsive: true,
        "ajax": {
            "url": 'CategoriaPage.aspx/ListaCategorias',
            "type": "POST",
            "contentType": "application/json; charset=utf-8",
            "dataType": "json",
            "data": function (d) {
                return JSON.stringify(d);
            },
            "dataSrc": function (json) {
                if (json.d.Estado) {
                    console.log(json.d.Mensaje);
                    return json.d.Data;
                } else {
                    return [];
                }
            }
        },
        "columns": [
            { "data": "IdCategoria", "visible": false, "searchable": false },
            { "data": "NombreCategoria", "className": "align-middle" },
            {
                "defaultContent": '<button class="btn btn-primary btn-editar btn-sm mr-2"><i class="fas fa-pencil-alt"></i></button>' +
                    '<button class="btn btn-success btn-detalle btn-sm"><i class="fas fa-address-book"></i></button>',
                "orderable": false,
                "searchable": false,
                "width": "100px",
                "className": "text-center align-middle"
            }
        ],
        "order": [[0, "desc"]],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        }
    });
}

$("#btnRegistroCat").on("click", function () {

    $("#myModalLabel").text("Nuevo Registro");

    $("#mdData").modal("show");
})