@Code
    ViewData("Title") = "CrearReunion"
End Code


<div class="container">
    <div id="customPadding">
        <div class="long-title"><h3>Lista Asistencia</h3></div>

        <div id="botonCrear" data-bind="dxButton: applyButtonOptionsCrear"> </div>

        <div id="grid" data-bind="dxDataGrid: grid"></div>
    </div>
</div>

@Section Scripts
    <script src="~/Scripts/app/Reuniones/CrearReunionViewModel.js"></script>
    <script>
        ko.applyBindings(new Reuniones.CrearReunionViewModel());
    </script>
End Section