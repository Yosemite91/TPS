@Code
    ViewData("Title") = "ListarPublicacionEventos"
End Code

<div id="cuerpoLista">
    <div class="long-title"><h3>Eventos</h3></div>
    <div id="botonCrear" data-bind="dxButton: applyButtonOptionsCrear"> </div>
    <div id="grid" data-bind="dxDataGrid: grid"></div>
</div>


@Section Scripts
    <script src="~/Scripts/app/PublicacionEventos/ListarPublicacionEventosViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionEventos.ListarPublicacionEventosViewModel());
    </script>
End Section