﻿$(document).ready(function () {

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
        scrollX: true, // Habilitar scroll horizontal
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
                exportOptions: {
                    columns: ':not(:last-child)' // Excluir la última columna
                },
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

//CheckList
$(document).ready(function () {
    $.fn.dataTable.ext.order['custom-folio-sort'] = function (settings, colIdx) {
        return this.api().column(colIdx, { order: 'index' }).nodes().map(function (td, i) {
            var val = $(td).text();
            var match = val.match(/^SC(\d+)-/); // Extraer la parte numérica después de "SC"
            return match ? parseInt(match[1], 10) : 0; // Convertir a entero para comparación numérica
        });
    };

    $('#tb_checklist').DataTable({
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        columnDefs: [
            {
                targets: 0,
                visible: true,
                orderDataType: 'custom-folio-sort'
            }
        ],
        scrollX: true, // Habilitar scroll horizontal
        dom: 'BfrtipC',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Excel',
                filename: 'Revision Montacargas',
                title: 'Revision Montacargas',
                exportOptions: {
                    columns: ':not(:last-child)'
                },
                className: 'btn-exportar-excel',
            },
            {
                extend: 'pdfHtml5',
                text: 'PDF',
                filename: 'Revision Montacargas',
                title: 'Revision Montacargas',
                exportOptions: {
                    columns: ':not(:last-child)'
                },
                className: 'btn-exportar-pdf',
            },
            {
                extend: 'print',
                title: 'Revision Montacargas',
                exportOptions: {
                    columns: ':not(:last-child)' // Excluir la última columna
                },
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

$(document).ready(function () {
    $.fn.dataTable.ext.order['custom-folio-sort'] = function (settings, colIdx) {
        return this.api().column(colIdx, { order: 'index' }).nodes().map(function (td, i) {
            var val = $(td).text();
            var match = val.match(/^SP(\d+)-/); // Extraer la parte numérica después de "SC"
            return match ? parseInt(match[1], 10) : 0; // Convertir a entero para comparación numérica
        });
    };

    $('#tb_serviciop').DataTable({
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        columnDefs: [
            {
                targets: 0,
                visible: true,
                orderDataType: 'custom-folio-sort'
            }
        ],
        scrollX: true, // Habilitar scroll horizontal
        dom: 'BfrtipC',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Excel',
                filename: 'Servicio P Montacargas',
                title: 'Revision Montacargas',
                exportOptions: {
                    columns: ':not(:last-child)'
                },
                className: 'btn-exportar-excel',
            },
            {
                extend: 'pdfHtml5',
                text: 'PDF',
                filename: 'Revision Montacargas',
                title: 'Revision Montacargas',
                exportOptions: {
                    columns: ':not(:last-child)'
                },
                className: 'btn-exportar-pdf',
            },
            {
                extend: 'print',
                title: 'Revision Montacargas',
                exportOptions: {
                    columns: ':not(:last-child)' // Excluir la última columna
                },
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
                targets: [6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,38], // Índices de las columnas que deseas ocultar
                visible: false, // Ocultar estas columnas
                searchable: false // Opcional: también puedes desactivar la búsqueda en estas columnas
            }
        ],
        scrollX: true, // Habilitar scroll horizontal
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
                exportOptions: {
                    columns: ':not(:last-child)' // Excluir la última columna
                },
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
        ]
    });
});






$(document).ready(function () {

    $.fn.dataTable.ext.order['custom-folio-sort'] = function (settings, colIdx) {
        return this.api().column(colIdx, { order: 'index' }).nodes().map(function (td, i) {
            var val = $(td).text();
            var match = val.match(/^SC(\d+)-/); // Extraer la parte numérica después de "SC"
            return match ? parseInt(match[1], 10) : 0; // Convertir a entero para comparación numérica
        });
    };

    $('#tb_salida thead tr').clone(true).addClass('filters').appendTo('#tb_salida thead');


    $('#tb_salida').DataTable({
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
                visible: true,
                orderDataType: 'custom-folio-sort'
            }
        ],
        scrollX: true, // Habilitar scroll horizontal
        //_______________ CUARTO ______________
        dom: 'BfrtipC',
        buttons: [
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Excel',
                filename: 'Lista Salidas',
                title: 'Lista Salidas de Almacen',
                exportOptions: {
                    columns: ':not(:last-child)' // Excluir la última columna
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            //{
            //    extend: 'pdfHtml5',
            //    text: 'PDF',
            //    filename: 'Lista Montacargas',
            //    title: 'Lista Montacargas',
            //    exportOptions: {
            //        columns: ':not(:last-child)' // Excluir la última columna
            //    },
            //    className: 'btn-exportar-pdf',
            //},
            //'print'
            {
                extend: 'print',
                title: 'Lista Montacargas',
                exportOptions: {
                    columns: ':not(:last-child)' // Excluir la última columna
                },
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