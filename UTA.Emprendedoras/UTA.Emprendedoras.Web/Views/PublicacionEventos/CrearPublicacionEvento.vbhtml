@Code
    ViewData("Title") = "CrearPublicacionEvento"
End Code

<div data-bind="dxPopup: popUpCrear"></div>
<div data-bind="dxPopup: popUpCancelar"></div>

<div id="cuerpoLista">

    <div class="row">
        <div id="botonesDetalle">
            <div id="solicitar-button" data-bind="dxButton: botonCancelar"> </div>
            <div id="solicitar-button" data-bind="dxButton: botonGuardar"> </div>
        </div>
    </div>

    <div class="row">
        @* INFORMACIÓN EVENTO *@
        <div class="dx-fieldset">
            <div class="dx-fieldset-header">Información del Evento</div>

            <div class="dx-field">
                <div class="dx-field-label">Título</div>
                <div class="dx-field-value">
                    <div data-bind="dxTextBox: dxTitulo, dxValidator: validatorOptions"></div>
                </div>
            </div>

            <div class="dx-field">
                <div class="dx-field-label">Descripción</div>
                <div class="dx-field-value">
                    <div data-bind="dxTextBox: dxDescripcion, dxValidator: validatorOptions"></div>
                </div>
            </div>

            @*<div class="dx-field">
                <div class="dx-field-label">Fecha Realización</div>
                <div class="dx-field-value">
                    <div data-bind="dxDateBox: dxFechaRealizacion, dxValidator: validatorOptions"></div>
                </div>
            </div>*@

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
</div>

@Section Scripts
    <script src="~/Scripts/app/PublicacionEventos/CrearPublicacionEventoViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionEventos.CrearPublicacionEventoViewModel());
    </script>
End Section

