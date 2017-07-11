@Code
    ViewData("Title") = "Detalle Noticia"
End Code

<div id="cuerpoLista">
    <div id="customPadding">
        <div data-bind="dxLoadPanel: { visible: loading }"></div>

        <div class="long-title"><h3>Detalle de la Noticia</h3></div>

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

