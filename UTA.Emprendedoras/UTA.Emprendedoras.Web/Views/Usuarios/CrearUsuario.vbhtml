@Code
    ViewData("Title") = "CrearUsuario"
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
        @* INFORMACIÓN USUARIO *@
        <div class="dx-fieldset">
            <div class="dx-fieldset-header">Información Personal</div>

            <div class="dx-field">
                <div class="dx-field-label">Nombre</div>
                <div class="dx-field-value">
                    <div data-bind="dxTextBox: dxNombre, dxValidator: validatorOptions"></div>
                </div>
            </div>

            <div class="dx-field">
                <div class="dx-field-label">Apellido</div>
                <div class="dx-field-value">
                    <div data-bind="dxTextBox: dxApellido, dxValidator: validatorOptions"></div>
                </div>
            </div>

            <div class="dx-field">
                <div class="dx-field-label">Run</div>
                <div class="dx-field-value">
                    <div data-bind="dxTextBox: dxRun, dxValidator: validatorOptions"></div>
                </div>
            </div>

            <div class="dx-field">
                <div class="dx-field-label">Teléfono</div>
                <div class="dx-field-value">
                    <div data-bind="dxNumberBox: dxTelefono"></div>
                </div>
            </div>

            <div class="dx-field">
                <div class="dx-field-label">Fecha Nacimiento</div>
                <div class="dx-field-value">
                    <div data-bind="dxDateBox: dxFechaNacimiento, dxValidator: validatorOptions"></div>
                </div>
            </div>

            <div class="dx-field">
                <div class="dx-field-label">¿Es Admin Sistema?</div>
                <div class="dx-field-value">
                    <div data-bind="dxSwitch: dxEsAdminSistema"></div>
                </div>
            </div>

            <div class="dx-field">
                <div class="dx-field-label">¿Es Administrador de Publicación?</div>
                <div class="dx-field-value">
                    <div data-bind="dxSwitch: dxEsAdminPublicacion"></div>
                </div>
            </div>

            <div class="dx-field">
                <div class="dx-field-label">Sitio Web</div>
                <div class="dx-field-value">
                    <div data-bind="dxTextBox: dxSitioWeb, dxValidator: validatorOptions"></div>
                </div>
            </div>

            <div class="dx-field">
                <div class="dx-field-label">Categoría</div>
                <div class="dx-field-value">
                    <div data-bind="dxTextBox: dxCategoria, dxValidator: validatorOptions"></div>
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
    <script src="~/Scripts/app/Usuarios/CrearUsuarioViewModel.js"></script>
    <script>
        ko.applyBindings(new Usuarios.CrearUsuarioViewModel());
    </script>
End Section
