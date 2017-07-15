@Code
    ViewData("Title") = "DetalleReunion"
End Code

<!-- ko if: esAdministrador === 'true' -->
<div id="titulo" class="long-title"><h3>Editar Lista Asistencia</h3></div>
<div class="container">
    <div id="customPadding">        
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
                <div id="solicitar-button" data-bind="dxButton: botonEditar"> </div>
            </div>
        </div>

    </div>
</div>
<!-- /ko -->
@Section Scripts
    <script src="~/Scripts/app/Reuniones/DetalleReunionViewModel.js"></script>
    <script>
        ko.applyBindings(new Reuniones.DetalleReunionViewModel());
    </script>
End Section
