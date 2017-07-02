@Code
    ViewData("Title") = "ListarPublicacionNoticias"
End Code

<div id="cuerpoLista">
    <div class="long-title"><h3>Noticias</h3></div>
    <div id="botonCrear" data-bind="dxButton: applyButtonOptionsCrear"> </div>
    <div id="grid" data-bind="dxDataGrid: grid"></div>
</div>


@Section Scripts
    <script src="~/Scripts/app/PublicacionNoticias/ListarPublicacionNoticiasViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionNoticias.ListarPublicacionNoticiasViewModel());
    </script>
End Section