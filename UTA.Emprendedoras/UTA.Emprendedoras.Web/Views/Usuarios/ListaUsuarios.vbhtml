@Code
    ViewData("Title") = "Lista Usuarios"
End Code

<!-- ko if: esAdministrador === 'true' || esAdminPublicacion === 'true' -->
<div class="container">
    <div id="customPadding">
        <div class="long-title"><h3>Usuarios</h3></div>

        <div id="botonCrear" data-bind="dxButton: applyButtonOptionsCrear"> </div>

        <div id="grid" data-bind="dxDataGrid: grid"></div>
    </div>
</div>
<!-- /ko -->

@Section Scripts
    <script src="~/Scripts/app/Usuarios/ListaUsuariosViewModel.js"></script>
    <script>
        ko.applyBindings(new Usuarios.ListaUsuariosViewModel());
    </script>
End Section
