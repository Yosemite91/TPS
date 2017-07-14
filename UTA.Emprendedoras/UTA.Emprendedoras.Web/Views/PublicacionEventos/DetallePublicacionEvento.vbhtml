@Code
    ViewData("Title") = "Detalle Evento"
End Code
<div id="titulo" class="long-title"><h3>Detalle del Evento</h3></div>

<div class="container">
    <div id="customPadding">
        <div data-bind="dxLoadPanel: { visible: loading }"></div>

        <div id="botonesDetalle">
            <div id="volver" data-bind="dxButton: goBack"> </div>
        </div>

        <div id="evento-form" data-bind="dxForm: form"></div>

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
    <script src="~/Scripts/app/PublicacionEventos/DetallePublicacionEventoViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionEventos.DetallePublicacionEventoViewModel());
    </script>
End Section

