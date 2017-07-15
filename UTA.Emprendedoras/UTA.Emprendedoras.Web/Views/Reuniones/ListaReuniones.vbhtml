@Code
    ViewData("Title") = "ListaReuniones"
End Code
<!-- ko if: esAdministrador === 'true' -->
<div id="titulo" class="long-title"><h3> Reuniones</h3></div>

<div class="container">
    <div id="customPadding">         
        <div id="grid" data-bind="dxDataGrid: grid"></div>

        <div class="row">
            <div id="botonesDetalle">
                <div id="solicitar-button" data-bind="dxButton: botonAgregar"> </div>
            </div>
        </div>
    </div>
</div>
<!-- /ko -->
@Section Scripts
    <script src="~/Scripts/app/Reuniones/ListaReunionesViewModel.js"></script>
    <script>
        ko.applyBindings(new Reuniones.ListaReunionesViewModel());
    </script>
End Section