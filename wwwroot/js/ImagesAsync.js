var loadImageUrl1 = '@Url.Action("LoadImage", "EntregaMtnCrg", new { id = Model?.IdEntregaMntCrg, imageNumber = 1 })';
var loadImageUrl2 = '@Url.Action("LoadImage", "EntregaMtnCrg", new { id = Model?.IdEntregaMntCrg, imageNumber = 2 })';

$(document).ready(function () {
    loadAsyncImage('#evidenciaImagen1', loadImageUrl1, '#imagen1Container');
    loadAsyncImage('#evidenciaImagen2', loadImageUrl2, '#imagen2Container');
});

function loadAsyncImage(imageId, imageUrl, containerId) {
    $.ajax({
        url: imageUrl,
        type: 'GET',
        success: function (data) {
            $(containerId).html('<img id="' + imageId + '" src="data:image;base64,' + data + '" alt="Evidencia" />');
        }
    });
}