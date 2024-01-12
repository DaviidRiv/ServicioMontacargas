$(document).ready(function () {
    // Ancho original del navbar
    var originalWidth = $('#sidebar').width();

    // Muestra u oculta el menú al hacer clic en el botón
    $('#menu-toggle').click(function (e) {
        e.preventDefault(); // Evita que el enlace realice la acción predeterminada
        console.log("entre2");

        var sidebar = $('#sidebar');
        if (sidebar.width() > 0) {
            // Si el navbar está visible, reducir su ancho a 0 para mostrar solo los iconos
            sidebar.animate({ width: 50 });
        } else {
            // Si el navbar está oculto, restaurar su ancho original
            sidebar.animate({ width: originalWidth });
        }
    });

    // Oculta el menú al hacer clic fuera del menú
    $(document).mouseup(function (e) {
        var container = $("#sidebar");
        if (!container.is(e.target) && container.has(e.target).length === 0) {
            console.log("entre3");

            // Oculta el navbar al hacer clic fuera de él
            container.animate({ width: 50 });
        }
    });
});
