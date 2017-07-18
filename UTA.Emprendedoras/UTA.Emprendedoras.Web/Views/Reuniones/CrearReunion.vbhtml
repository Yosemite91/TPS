@Code
    ViewData("Title") = "CrearReunion"
End Code
<!-- ko if: esAdministrador === 'true' -->
<div id="titulo" class="long-title"><h3>Lista Asistencia</h3></div>

<div class="container">
    <div data-bind="dxLoadPanel: { visible: loading }"></div>
    <div id="customPadding">
        <div class="row">
            <div id="botonesDetalle">
                <div id="volver" data-bind="dxButton: goBack"> </div>
                <div id="botonCrear" data-bind="dxButton: applyButtonOptionsCrear"> </div>
            </div>
        </div>

        <div class="row">
            <div class="dx-fieldset">
                <div class="dx-fieldset-header">Información de la Reunión</div>
                <div class="dx-field">
                    <div class="dx-field-label">Descripción</div>
                    <div class="dx-field-value">
                        <div data-bind="dxTextBox: dxDescripcion"></div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="dx-field">
            <div class="dx-field-label">Asistencia:</div>
            <div id="grid" data-bind="dxDataGrid: grid"></div>
        </div>
    </div>
</div>
<!-- /ko -->
@Section Scripts
    <script src="~/Scripts/app/Reuniones/CrearReunionViewModel.js"></script>
    <script>
        ko.applyBindings(new Reuniones.CrearReunionViewModel());
    </script>
End Section