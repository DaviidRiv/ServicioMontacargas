$(document).ready(function () {

    $('#tb_monta thead tr').clone(true).addClass('filters').appendTo('#tb_monta thead');


    $('#tb_monta').DataTable({
        //________________ SEGUNDO ____________
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        paging: true, // Habilita la paginación
        pageLength: 10,
        //________________ TERCERO ____________
        columnDefs: [
            {
                targets: 0,
                visible: true
            }
        ],
        //_______________ CUARTO ______________
        dom: 'BfrtipC',
        buttons: [
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Excel',
                filename: 'Lista Montacargas',
                title: 'Lista Montacargas',
                exportOptions: {
                    columns: ':not(:last-child)' // Excluir la última columna
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'PDF',
                filename: 'Lista Montacargas',
                title: 'Lista Montacargas',
                exportOptions: {
                    columns: ':not(:last-child)' // Excluir la última columna
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Lista Montacargas',
                className: 'btn-exportar-print'

            },
            {
                extend: 'colvis',
                text: 'Columnas',
                className: 'btn-colvis',
                collectionLayout: 'fixed three-column'
            },
            //extra
            'pageLength'
        ],
        //______________ QUINTO _______________
        orderCellsTop: true,
        fixedHeader: true,
        initComplete: function () {
            var api = this.api();

            // For each column
            api.columns().eq(0).each(function (colIdx) {

                // Set the header cell to contain the input element
                var cell = $('.filters th').eq($(api.column(colIdx).header()).index());

                var title = $(cell).text();

                //$(cell).html('<input type="text" placeholder="' + title + '" />');
                $(cell).html('<input type="text" placeholder="" />');

                // On every keypress in this input
                $('input', $('.filters th').eq($(api.column(colIdx).header()).index())).off('keyup change').on('keyup change', function (e) {

                    e.stopPropagation();

                    // Get the search value
                    $(this).attr('title', $(this).val());

                    var regexr = '({search})'; //$(this).parents('th').find('select').val();

                    var cursorPosition = this.selectionStart;
                    // Search the column for that value
                    api
                        .column(colIdx)
                        .search(
                            this.value != ''
                                ? regexr.replace('{search}', '(((' + this.value + ')))')
                                : '',
                            this.value != '',
                            this.value == ''
                        )
                        .draw();

                    $(this)
                        .focus()[0]
                        .setSelectionRange(cursorPosition, cursorPosition);
                });
            });
        },
    });
}); 

//EntregaMontacarga
$(document).ready(function () {

    $('#tb_entrega').DataTable({
        //________________ SEGUNDO ____________
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        //________________ TERCERO ____________
        columnDefs: [
            {
                targets: 0,
                visible: true
            }
        ],
        //_______________ CUARTO ______________
        dom: 'BfrtipC',
        buttons: [
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Excel',
                filename: 'Entrega Montacarga',
                title: 'Entrega Montacarga',
                exportOptions: {
                    columns: ':not(:last-child)' // Excluir la última columna
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'PDF',
                filename: 'Entrega Montacarga',
                title: 'Entrega Montacarga',
                exportOptions: {
                    columns: ':not(:last-child)' // Excluir la última columna
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Entrega Montacarga',
                className: 'btn-exportar-print'

            },
            {
                extend: 'colvis',
                text: 'Columnas',
                className: 'btn-colvis',
                collectionLayout: 'fixed three-column'
            },
            //extra
            'pageLength'
        ],
        //______________ QUINTO _______________
    });
});

//CheckList
$(document).ready(function () {
    $('#tb_checklist').DataTable({
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        columnDefs: [
            {
                targets: 0,
                visible: true
            }
        ],
        scrollX: true, // Habilitar scroll horizontal
        dom: 'BfrtipC',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Excel',
                filename: 'CheckList Montacargas',
                title: 'CheckList Montacargas',
                exportOptions: {
                    columns: ':not(:last-child)'
                },
                className: 'btn-exportar-excel',
            },
            {
                extend: 'pdfHtml5',
                text: 'PDF',
                filename: 'CheckList Montacargas',
                title: 'CheckList Montacargas',
                exportOptions: {
                    columns: ':not(:last-child)'
                },
                className: 'btn-exportar-pdf',
            },
            {
                extend: 'print',
                title: 'CheckList Montacargas',
                className: 'btn-exportar-print'
            },
            {
                extend: 'colvis',
                text: 'Columnas',
                className: 'btn-colvis',
                collectionLayout: 'fixed three-column'
            },
            'pageLength'
        ],
    });
});
