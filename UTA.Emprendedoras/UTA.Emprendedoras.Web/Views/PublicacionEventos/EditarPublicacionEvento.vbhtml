@Code
    ViewData("Title") = "Modificar Evento"
End Code
<!-- ko if: esAdministrador === 'true' || esAdminPublicacion === 'true' -->
<div data-bind="dxPopup: popUpModificar"></div>
<div data-bind="dxPopup: popUpCancelar"></div>
<div id="titulo" class="long-title"><h3>Editar Evento</h3></div>

<div class="container">
    <div data-bind="dxLoadPanel: { visible: loading }"></div>
    <div id="customPadding">       
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

                <div class="dx-field">
                    <div class="dx-field-label">Fecha Realización</div>
                    <div class="dx-field-value">
                        <div data-bind="dxDateBox: dxFechaRealizacion"></div>
                    </div>
                </div>

                <br />
                @* UPLOAD IMAGE *@
                <div class="dx-fieldset-header" style="margin:0">Foto Perfil</div>
                <div class="dx-field">
                    <div class="dx-field-value">
                        <div data-bind="dxFileUploader: dxSubirImagen"></div>
                    </div>
                </div> 
            </div>
        </div>

        <div class="row">
            <div id="botonesDetalle">
                <div id="solicitar-button" data-bind="dxButton: botonCancelarEdicion"> </div>
                <div id="solicitar-button" data-bind="dxButton: botonGuardar"> </div>
            </div>
        </div>
    </div>
</div>
<!-- /ko -->
@Section Scripts
    <script src="~/Scripts/app/PublicacionEventos/EditarPublicacionEventoViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionEventos.EditarPublicacionEventoViewModel());
    </script>
End Section