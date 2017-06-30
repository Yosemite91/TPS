@Code
    ViewData("Title") = "DetallePublicacionNoticia"
End Code

<div id="cuerpoLista">
    <div data-bind="dxLoadPanel: { visible: loading }"></div>

    <div class="row">
        <div id="botonesDetalle">
            <div id="solicitar-button" data-bind="dxButton: botonEditar"> </div>
        </div>
    </div>

    <div id="noticia-form" data-bind="dxForm: form"></div>

</div>


@Section Scripts
    <script src="~/Scripts/app/PublicacionNoticias/DetallePublicacionNoticiaViewModel.js"></script>
    <script>
        ko.applyBindings(new PublicacionNoticias.DetallePublicacionNoticiaViewModel());
    </script>
End Section

