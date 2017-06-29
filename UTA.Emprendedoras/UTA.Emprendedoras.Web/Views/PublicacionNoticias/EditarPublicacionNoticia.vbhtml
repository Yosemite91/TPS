@Code
    ViewData("Title") = "EditarPublicacionNoticia"
End Code

<div data-bind="dxPopup: popUpModificar"></div>
<div data-bind="dxPopup: popUpCancelar"></div>


<div id="cuerpoLista">
    <div data-bind="dxLoadPanel: { visible: loading }"></div>

    <div class="row">
        <div id="botonesDetalle">
            <div id="solicitar-button" data-bind="dxButton: botonCancelarEdicion"> </div>
            <div id="solicitar-button" data-bind="dxButton: botonGuardar"> </div>
        </div>
    </div>

    <div class="row">
        @* INFORMACIÓN EVENTO *@
        <div class="dx-fieldset">
            <div class="dx-fieldset-header">Información de la Noticia</div>

            <div class="dx-field">
                <div class="dx-field-label">Titulo</div>
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
    <script src="~/Scripts/app/PublicacionNoticias/EditarPublicacionNoticiaViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionNoticias.EditarPublicacionNoticiaViewModel());
    </script>
End Section

