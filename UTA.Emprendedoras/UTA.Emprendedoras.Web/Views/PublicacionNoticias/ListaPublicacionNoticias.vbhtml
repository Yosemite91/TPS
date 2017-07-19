@Code
    ViewData("Title") = "Lista Noticias"
End Code
<div id="titulo" class="long-title"><h3>Noticias</h3></div>
<div class="container">
    <div data-bind="dxLoadPanel: { visible: loading }"></div>
    <div id="customPadding">        
        <div id="botonesDetalle">
            <div id="volver" data-bind="dxButton: goBack"> </div>
            <!-- ko if: esAdministrador === 'true' || esAdminPublicacion === 'true' -->
            <div id="botonCrear" data-bind="dxButton: applyButtonOptionsCrear"> </div>
            <!-- /ko -->            
        </div>        
        <div id="grid" data-bind="dxDataGrid: grid"></div>
    </div>
</div>

@Section Scripts
    <script src="~/Scripts/app/PublicacionNoticias/ListarPublicacionNoticiasViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionNoticias.ListarPublicacionNoticiasViewModel());
    </script>
End Section
