@Code
    ViewData("Title") = "Lista Eventos"
End Code
<div id="titulo" class="long-title"><h3>Eventos</h3></div>

<div class="container">
    <div id="customPadding">        
        <!-- ko if: esAdministrador === 'true' || esAdminPublicacion === 'true' -->
        <div id="botonCrear" data-bind="dxButton: applyButtonOptionsCrear"> </div>
        <!-- /ko -->
        <div id="grid" data-bind="dxDataGrid: grid"></div>
    </div>
</div>

@Section Scripts
    <script src="~/Scripts/app/PublicacionEventos/ListarPublicacionEventosViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionEventos.ListarPublicacionEventosViewModel());
    </script>
End Section