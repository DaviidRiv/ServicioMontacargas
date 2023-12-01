document.addEventListener("DOMContentLoaded", function (event) {

    const showNavbar = (toggleId, navId, bodyId, headerId) => {
        const toggle = document.getElementById(toggleId),
            nav = document.getElementById(navId),
            bodypd = document.getElementById(bodyId),
            headerpd = document.getElementById(headerId)

        // Validate that all variables exist
        if (toggle && nav && bodypd && headerpd) {
            toggle.addEventListener('click', () => {
                // show navbar
                nav.classList.toggle('show');
                // change icon
                toggle.classList.toggle('bx-x');
                // add padding to body
                bodypd.classList.toggle('body-pd');
                // add padding to header
                headerpd.classList.toggle('body-pd');
            });
        }
    };

    showNavbar('header-toggle', 'nav-bar', 'body-pd', 'header');

    /*===== LINK ACTIVE =====*/
    const linkColor = document.querySelectorAll('.nav_link');

    function colorLink() {
        if (linkColor) {
            linkColor.forEach(l => l.classList.remove('active'));
            this.classList.add('active');
            localStorage.setItem('selectedLink', this.href);
        }
    }

    // Solo activa el primer enlace al cargar la página
    linkColor[0].classList.add('active');

    // Add logic para marcar el enlace activo basado en la URL actual o el enlace almacenado
    linkColor.forEach((l, index) => {
        const storedLink = localStorage.getItem('selectedLink');
        if (index !== 0 && ((index === 0 && !storedLink) || (storedLink && l.href === storedLink))) {
            l.classList.add('active');
        } else if (window.location.href.indexOf(l.href) > -1) {
            l.classList.add('active');
        }

        l.addEventListener('click', colorLink);
    });

    // Tu código para ejecutar una vez que el DOM está cargado y listo
});
