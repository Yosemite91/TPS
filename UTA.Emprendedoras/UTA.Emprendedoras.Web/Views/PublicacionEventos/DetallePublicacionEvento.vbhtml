﻿@Code
    ViewData("Title") = "DetallePublicacionEvento"
End Code

<div id="cuerpoLista">
    <div data-bind="dxLoadPanel: { visible: loading }"></div>

    <div class="row">
        <div id="botonesDetalle">
            <div id="solicitar-button" data-bind="dxButton: botonEditar"> </div>
        </div>
    </div>

    <div id="evento-form" data-bind="dxForm: form"></div>

</div>


@Section Scripts
    <script src="~/Scripts/app/PublicacionEventos/DetallePublicacionEventoViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionEventos.DetallePublicacionEventoViewModel());
    </script>
End Section
