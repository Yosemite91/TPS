@Code
    ViewData("Title") = "EditarReunion"
End Code
<div data-bind="dxPopup: popUpModificar"></div>
<div class="container">
    <div id="customPadding">
        <div class="long-title"><h3>Editar Lista Asistencia</h3></div>

        @*<div id="botonCrear" data-bind="dxButton: applyButtonOptionsCrear"> </div>*@

                <div class="row">
            <div class="dx-fieldset">
                <div class="dx-field">
                    <div class="dx-field-label">Descripción</div>
                    <div class="dx-field-value">
                        <div data-bind="dxTextBox: dxDescripcion"></div>
                    </div>
                </div>
            </div>
        </div>

        <div id="grid" data-bind="dxDataGrid: grid"></div>

        <div class="row">
            <div id="botonesDetalle">
                <div id="solicitar-button" data-bind="dxButton: botonGuardar"> </div>
            </div>
        </div>
    </div>
</div>

@Section Scripts
    <script src="~/Scripts/app/Reuniones/EditarReunionViewModel.js"></script>
    <script>
        ko.applyBindings(new Reuniones.EditarReunionViewModel());
    </script>
End Section

