@Code
    ViewData("Title") = "ListaReuniones"
End Code
<!-- ko if: esAdministrador === 'true' -->
<div id="titulo" class="long-title"><h3>Reuniones</h3></div>

<div class="container">
    <div data-bind="dxLoadPanel: { visible: loading }"></div>
    <div id="customPadding">                 
        <div id="botonesDetalle">
            <div id="volver" data-bind="dxButton: goBack"> </div>
            <!-- ko if: esAdministrador === 'true' -->
            <div id="botonCrear" data-bind="dxButton: botonAgregar"> </div>
            <!-- /ko -->
        </div>        

        <div id="grid" data-bind="dxDataGrid: grid"></div>        
    </div>
</div>
<!-- /ko -->
@Section Scripts
    <script src="~/Scripts/app/Reuniones/ListaReunionesViewModel.js"></script>
    <script>
        ko.applyBindings(new Reuniones.ListaReunionesViewModel());
    </script>
End Section