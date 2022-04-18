$('.btn_menu').click(function () {
    $(this).toggleClass("click");
    $('.sidebar').toggleClass("show");
});

$(document).ready(function () {
    getDatatable('#table_pedidos');
})

function getDatatable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrat de _MAX_ total registro",
            "sInfoPostFlix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando",
            "sZeroRecords": "Nenhum registro encontado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": "Ordenar colunas de forma ascendente",
                "sSortDescending": "Ordenar colunas de forma descendente"
            }
        }
    });
}