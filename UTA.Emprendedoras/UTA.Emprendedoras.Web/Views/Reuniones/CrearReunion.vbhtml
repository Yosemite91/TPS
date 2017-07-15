@Code
    ViewData("Title") = "CrearReunion"
End Code
<div id="titulo" class="long-title"><h3>Lista Asistencia</h3></div>

<div class="container">
    <div id="customPadding">        
        <div id="botonCrear" data-bind="dxButton: applyButtonOptionsCrear"> </div>

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
    </div>
</div>

@Section Scripts
    <script src="~/Scripts/app/Reuniones/CrearReunionViewModel.js"></script>
    <script>
        ko.applyBindings(new Reuniones.CrearReunionViewModel());
    </script>
End Section