﻿@Code
    ViewData("Title") = "Detalle Noticia"
End Code
<div id="titulo" class="long-title">
    <h3>Detalle de la Noticia</h3>
    <div data-bind="foreach: fotoPerfil">
        <img style="margin-bottom: 10px" class="mg-circle img-responsive bubble" id="perfilNoticia" data-bind="attr: {src: cuerpo, alt: nombre}">
    </div>
</div>

<div class="container">
    <div id="customPadding">
        <div data-bind="dxLoadPanel: { visible: loading }"></div>

        <div id="botonesDetalle">
            <div id="volver" data-bind="dxButton: goBack"> </div>
        </div>

        <div id="noticia-form" data-bind="dxForm: form"></div>

        <!-- ko if: esAdministrador === 'true' || esAdminPublicacion === 'true' -->
        <div class="row">
            <div id="botonesDetalle">
                <div id="solicitar-button" data-bind="dxButton: botonEliminar"> </div>
                <div id="solicitar-button" data-bind="dxButton: botonEditar"> </div>
            </div>
        </div>
        <!-- /ko -->
    </div>
</div>

@Section Scripts
    <script src="~/Scripts/app/PublicacionNoticias/DetallePublicacionNoticiaViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionNoticias.DetallePublicacionNoticiaViewModel());
    </script>
End Section

