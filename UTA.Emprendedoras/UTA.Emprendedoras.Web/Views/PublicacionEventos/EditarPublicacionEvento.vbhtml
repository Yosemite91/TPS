@Code
    ViewData("Title") = "EditarPublicacionEvento"
End Code

<div data-bind="dxPopup: popUpModificar"></div>
<div data-bind="dxPopup: popUpCancelar"></div>


<div class="container">
    <div data-bind="dxLoadPanel: { visible: loading }"></div>

    <div class="long-title"><h3>Editar Evento</h3></div>    

    <div class="row">
        @* INFORMACIÓN EVENTO *@
        <div class="dx-fieldset">
            <div class="dx-fieldset-header">Información del Evento</div>

            <div class="dx-field">
                <div class="dx-field-label">Titulo</div>
                <div class="dx-field-value">
                    <div data-bind="dxTextBox: dxTitulo, dxValidator: validatorOptions"></div>
                </div>
            </div>

            <div class="dx-field">
                <div class="dx-field-label">Descripción</div>
                <div class="dx-field-value">
                    <div data-bind="dxTextArea: dxDescripcion, dxValidator: validatorOptions"></div>
                </div>
            </div>

            @* UPLOAD IMAGE *@
            @*<div class="dx-fieldset">
                <div class="dx-fieldset-header" style="margin:0">Foto Perfil</div>
                <div class="dx-field">
                    <div class="dx-field-value">
                        <div data-bind="dxFileUploader: dxSubirImagen"></div>
                    </div>
                </div>
            </div>*@

        </div>
    </div>

    <div class="row">
        <div id="botonesDetalle">
            <div id="solicitar-button" data-bind="dxButton: botonCancelarEdicion"> </div>
            <div id="solicitar-button" data-bind="dxButton: botonGuardar"> </div>
        </div>
    </div>
</div>


@Section Scripts
    <script src="~/Scripts/app/PublicacionEventos/EditarPublicacionEventoViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionEventos.EditarPublicacionEventoViewModel());
    </script>
End Section