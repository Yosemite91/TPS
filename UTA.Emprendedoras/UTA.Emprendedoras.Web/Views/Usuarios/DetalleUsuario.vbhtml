@Code
    ViewData("Title") = "Detalle Usuario"
End Code

<div class="container">
    <div id="customPadding">
        <div class="long-title"><h3>Detalle Usuario</h3></div>

        <div class="row">
            <div data-bind="dxLoadPanel: { visible: loading }"></div>

            <div id="botonesDetalle">
                <div id="volver" data-bind="dxButton: goBack"> </div>
                <div id="solicitar-button" data-bind="dxButton: applyButtonOptionsRestaurarPass"> </div>
            </div>

            <div id="usuario-form" data-bind="dxForm: form"></div>

            <div class="row">
                <div id="solicitar-button" data-bind="dxButton: botonBloquear"> </div>
                <div id="solicitar-button" data-bind="dxButton: botonDesbloquear"> </div>
                <div id="modificar-button" data-bind="dxButton: applyButtonOptionsModificar"> </div>
            </div>
        </div>
    </div>
</div>

@Section Scripts
    <script src="~/Scripts/app/Usuarios/DetalleUsuarioViewModel.js"></script>
    <script>
        ko.applyBindings(new Usuarios.DetalleUsuarioViewModel());
    </script>
End Section

